using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
using System.Text.RegularExpressions;

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour TransfertHypothecaire.xaml
    /// </summary>
    public partial class TransfertHypothecaire : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        SqlConnection connexion;
        SqlCommand commande;
        public TransfertHypothecaire(ClientActif client)
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
            this.client = client;
        }

        //pour transférer au compte épargne
        private void btnTransfert_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //si le client a un compte épargne
                if (verifCompteHypo() == true)
                {
                    //le client a assez pour le transfert
                    if (verifSoldeCheque() == true)
                    {
                        //si le montant est plus petit ou égale au montant du compte
                        if(verifMontantHypo() == true)
                        {
                            //on soustrait le montant dans chèque
                            retirerCheque();
                            //on ajout le montant dans épargnes
                            ajouterHypo();
                            //Message de réussite
                            MessageBox.Show("Transfert effectué.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            //on sauvegarde les transactions
                            sauvegardeTransfertChe();
                            sauvegardeTransfertHypo();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
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

        //pour retirer du compte chèque
        private void retirerCheque()
        {
            decimal montantSaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantSaisie);
            try
            {
                //requête
                string retirerCheque = "UPDATE cheques SET montant = montant - @montant WHERE codecli = @codecli";
                commande = new SqlCommand(retirerCheque, connexion);
                commande.Parameters.AddWithValue("@montant", montantSaisie);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Vous n'avez pas les fonds nécéssaires pour ce transfert, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour vérifier si le montant du compte cheque ne tombe pas en dessous de 0
        private bool verifSoldeCheque()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            decimal solde = 0;
            try
            {
                //requête
                string verifcheque = "SELECT * FROM cheques WHERE codecli = @codecli";
                commande = new SqlCommand(verifcheque, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if (lecteur.Read())
                {
                    decimal.TryParse(lecteur["montant"].ToString(), out solde);

                    if (montantsaisie > solde)
                    {
                        MessageBox.Show("Vous n'avez pas les fonds nécéssaires pour ce transfert, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
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

        //pour vérifier que le montant ne dépasse pas le solde hypo
        private bool verifMontantHypo()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            decimal montantcompte;
            try
            {
                //requête
                string verif = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(verif,connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if(lecteur.Read())
                {
                    decimal.TryParse(lecteur["montant"].ToString(), out montantcompte);

                    if(montantsaisie > montantcompte)
                    {
                        MessageBox.Show("Veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour ajouter les fonds dans le compte hypothecaire
        private void ajouterHypo()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);

            try
            {
                //requête
                string ajouterhypo = "UPDATE hypothecaires SET montant = montant - @montant WHERE codecli = @codecli";
                commande = new SqlCommand(ajouterhypo, connexion);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }

        //vérifier si le client à un compte hypothecaire
        private bool verifCompteHypo()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si cela retourne c'est que le client possède un compte épargne
                if (lecteur.Read())
                {
                    return true;
                }
                //sinon non
                else
                {
                    MessageBox.Show("Vous n'avez pas de compte hypothécaire, veuillez sélectionner un autre compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
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

        //pour sauvegarder l'opération sur le compte chèque (-)
        private void sauvegardeTransfertChe()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            try
            {
                //requête
                string transfertChe = "INSERT INTO transactions(codecli, typetransac, comptetransac, montant) VALUES (@codecli, 'Transfert de', 'Chèque', @montant)";
                commande = new SqlCommand(transfertChe, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
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

        //pour sauvegarder l'opération sur le compte hypothecaire (+)
        private void sauvegardeTransfertHypo()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            try
            {
                //requête
                string transfertHypo = "INSERT INTO transactions(codecli, typetransac, comptetransac, montant) VALUES (@codecli, 'Transfert vers', 'Hypothécaire', @montant)";
                commande = new SqlCommand(transfertHypo, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
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

        //pour limiter à seulement des chiffres
        private void txtMontant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre ou un point
            Regex regex = new Regex(@"^\d*(\.\d{0,2})?$");

            // Récupère le texte actuel dans le TextBox
            var textBox = sender as TextBox;
            var newText = textBox.Text.Insert(textBox.CaretIndex, e.Text);

            // Vérifie si le nouveau texte correspond à l'expression régulière
            e.Handled = !regex.IsMatch(newText);
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

        //pour retourner au menu
        private void btnMenu_click(object sender, RoutedEventArgs e)
        {
            //on ramène au menu et envoit le client
            MenuPrincipal menuprinc = new MenuPrincipal(client);
            menuprinc.Show();
            //on ferme le premier form
            this.Close();
        }
    }
}
