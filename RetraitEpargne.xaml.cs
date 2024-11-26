using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlTypes;

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour RetraitEpargne.xaml
    /// </summary>
    public partial class RetraitEpargne : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        SqlConnection connexion;
        SqlCommand commande;
        public RetraitEpargne(ClientActif client)
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
            this.client = client;
        }

        //lorsqu'on clique sur retrait
        private void btnRetraitEpargne_click(object sender, RoutedEventArgs e)
        {
            //var pour le montant entré
            int montant;
            int.TryParse(txtMontant.Text, out montant);

            //si aucune valeur n'est entrée
            if (txtMontant.Text == string.Empty || montant == 0)
            {
                MessageBox.Show("Veuillez saisir une valeur.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //si le montant dépasse 1000$ ou n'est pas un multiple de 10
            if (montant > 1000 || montant % 10 != 0)
            {
                MessageBox.Show("Veuillez saisir un multiple de 10 seulement, minimum 10$, qui est plus petit ou égal à 1000$.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                //on quitte la méthode
                return;
            }


            //si les règles de retrait sont respecté on peut faire le retrait
            try
            {
                //si il n'y a pas assez de fonds
                if (verifFondGuichet() == false)
                {
                    return;
                }
                //si il y a assez de fonds on peut procéder
                else
                {
                    retraitChe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }


        //retraits soit sur compte normale ou sur marge de crédit en plus
        private void retraitChe()
        {
            //pour le montant qui fut saisit
            decimal montantSaisit;
            decimal difference = 0;
            decimal.TryParse(txtMontant.Text, out montantSaisit);
            try
            {
                //requête pour savoir on a combien dans le compte
                string soldeepargne = "SELECT * FROM epargnes WHERE codecli = @codecli";
                commande = new SqlCommand(soldeepargne, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();


                if (lecteur.Read())
                {
                    decimal montantCheque;
                    decimal.TryParse(lecteur["montant"].ToString(), out montantCheque);

                    //si le montant saisit est plus grand que le montant qu'on a dans le compte chèque
                    if (montantSaisit > montantCheque)
                    {
                        //on ferme la connexion currente
                        connexion.Close();
                        difference = montantSaisit - montantCheque;

                        //requête pour ajouter a la marge la différence
                        string ajoutmarge = "UPDATE marge SET montant = montant + @difference WHERE codecli = @codecli";
                        commande = new SqlCommand(ajoutmarge, connexion);
                        commande.Parameters.AddWithValue("@difference", difference);
                        commande.Parameters.AddWithValue("@codecli", client.codecli);
                        //on ouvre la connexion
                        connexion.Open();
                        //lecteur 
                        int ligneAffectee = commande.ExecuteNonQuery();
                        //si on a augmenter le compte marge de crédit
                        if (ligneAffectee > 0)
                        {
                            //on ferme la connexion
                            connexion.Close();
                            //on met à 0 le compte chèque
                            viderlecompte();

                            //on sauvegarde la transaction fait sur le compte chèque
                            //requête
                            string transacCheque = "INSERT INTO transactions(codecli, typetransac, comptetransac, montant) VALUES (@codecli, 'Retrait', 'Épargne', @montantepargne)";
                            commande = new SqlCommand(transacCheque, connexion);
                            commande.Parameters.AddWithValue("@codecli", client.codecli);
                            commande.Parameters.AddWithValue("@montantepargne", montantCheque);
                            //ouverture de connexion
                            connexion.Open();
                            commande.ExecuteNonQuery();
                            //fermeture de connexion
                            connexion.Close();

                            //on sauvegarde la transaction faite sur la marge de crédit
                            string transacMarge = "INSERT INTO transactions(codecli, typetransac, comptetransac, montant) VALUES (@codecli, 'Retrait sur marge', 'Marge', @emprunt)";
                            commande = new SqlCommand(transacMarge, connexion);
                            commande.Parameters.AddWithValue("@codecli", client.codecli);
                            commande.Parameters.AddWithValue("@emprunt", difference);
                            //ouverture de connexion
                            connexion.Open();
                            commande.ExecuteNonQuery();
                            //fermeture de connexion
                            connexion.Close();
                            //retirer les fonds du guichet
                            retirerFondsGuichet();

                            // on affiche le message de récupération d'argent et d'augmentation de la marge de crédit
                            MessageBox.Show("Vous pouvez récupérer votre argent.", "Information", MessageBoxButton.OK);
                            MessageBox.Show($"Le solde de votre compte marge de crédit a augmenté de " + difference + " $, puisque vous n'aviez pas assez dans le compte épargne.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        //cela veut dire que le client n'a pas de compte marge de crédit
                        else
                        {
                            MessageBox.Show("Fonds insuffisant, veuillez réduire le montant à retirer.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }

                    }
                    // on réduit normalement la valeur du compte
                    else
                    {
                        //on ferme la connexion
                        connexion.Close();
                        //on retire les fonds normalement du compte chèque
                        retraitNormalEpa();
                        //on retire les fonds du guichet
                        retirerFondsGuichet();
                        //on sauvegarde la transaction
                        sauvegarderRetraitEpaNormal();
                        //on affiche message de récupération d'argent
                        MessageBox.Show("Vous pouvez récupérer votre argent.", "Information", MessageBoxButton.OK);
                    }
                }
                //le client n'a pas de compte épargne
                else
                {
                    MessageBox.Show("Vous n'avez pas de compte épargne, veuillez choisir le compte chèque ou appelez votre banque pour vous créer un compte épargne.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }


        //lorsque le retrait dois piger dans marge de crédit alors on met le compte (chèque ou épargne) à 0
        private void viderlecompte()
        {
            try
            {
                //requête pour mettre à 0 le compte
                string vider = "UPDATE epargnes SET montant = 0 WHERE codecli = @codecli";
                commande = new SqlCommand(vider, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }


        //pour retirer les fonds normalement dans le compte chèque sans marge de crédit puisque montant est suffisant

        private void retraitNormalEpa()
        {
            //pour le montant qui fut saisit
            decimal montantSaisit;
            decimal.TryParse(txtMontant.Text, out montantSaisit);

            try
            {
                //requête
                string retirerfondnormal = "UPDATE epargnes SET montant = montant - @montant WHERE codecli = @codecli";
                commande = new SqlCommand(retirerfondnormal, connexion);
                commande.Parameters.AddWithValue("@montant", montantSaisit);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }


        //vérifie si il y a assez d'argent dans le guichet pour le retrait

        private bool verifFondGuichet()
        {
            int montantguichet = 0;
            int montantSaisie;
            int.TryParse(txtMontant.Text, out montantSaisie);
            try
            {
                //requête
                string fondsGuichet = "SELECT * FROM guichets WHERE idguichet = 1";
                commande = new SqlCommand(fondsGuichet, connexion);
                //on ouvre la connexion
                connexion.Open();
                //lecteur
                SqlDataReader lecteur = commande.ExecuteReader();

                //lorsqu'on recoit on lie le montant guichet à la variable
                if (lecteur.Read())
                {
                    int.TryParse(lecteur["montant"].ToString(), out montantguichet);

                    //si le retrait est plus grand que les fonds disponible dans le guichet alors on annule
                    if (montantSaisie > montantguichet)
                    {
                        MessageBox.Show("Le guichet ne dispose pas d'assez d'argent pour ce retrait, veuillez réduire le montant à retirer.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                        //on retourne false
                        return false;
                    }
                    //si le retrait est pas plus grand que le montant du guichet
                    else
                    {
                        return true;
                    }
                }
                //si rien n'est retourné
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }


        //pour retirer les fonds du guichet après un retrait
        private void retirerFondsGuichet()
        {
            int montantretire;
            int.TryParse(txtMontant.Text, out montantretire);
            try
            {
                //requête
                string retirerFondsGuichet = "UPDATE guichets SET montant = montant - @montantretire WHERE idguichet = 1";
                commande = new SqlCommand(retirerFondsGuichet, connexion);
                commande.Parameters.AddWithValue("@montantretire", montantretire);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour sauvegarder la transaction lorsque c'est un retrait normal sans marge de crédit
        private void sauvegarderRetraitEpaNormal()
        {
            //pour le montant qui fut saisit
            decimal montantretire;
            decimal.TryParse(txtMontant.Text, out montantretire);
            try
            {
                //requête
                string sauvegardeNormale = "INSERT INTO transactions(codecli, typetransac, comptetransac, montant) VALUES (@codecli, 'Retrait', 'Épargne', @montant)";
                commande = new SqlCommand(sauvegardeNormale, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                commande.Parameters.AddWithValue("@montant", montantretire);
                //on ouvre la connexion
                connexion.Open();
                //on exécute la requête
                commande.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }


        //pour limiter à seulement des chiffres sans point
        private void txtMontant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        //pour menu
        private void btnMenu_click(object sender, RoutedEventArgs e)
        {
            //on ramène au menu et envoit le client
            MenuPrincipal menuprinc = new MenuPrincipal(client);
            menuprinc.Show();
            //on ferme le premier form
            this.Close();
        }

        //pour quitter
        private void btnQuitter_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application?", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Fermeture de l'application.");
                this.Close();
            }
        }
    }
}
