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

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour AdminPreleverOP.xaml
    /// </summary>
    public partial class AdminPreleverOP : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminPreleverOP()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        private void btnPrelever_click(object sender, RoutedEventArgs e)
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);

            //si rien n'est entré ou que la valeur vaut 0
            if(txtMontant.Text == string.Empty || montantsaisie == 0)
            {
                MessageBox.Show("Veuillez saisir une valeur.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            //si le client existe 
            if(verifClient() == true)
            {
                //si le client possède un compte hypothécaire
                if(verifCompteHypo() == true)
                {
                    //si le client possède une marge de crédit
                    if(verifCompteMarge() == true)
                    {
                        //opérations
                        opMontantAvcMarge();
                    }
                    //si il ne possède pas de marge de crédit
                    else
                    {
                        //opération
                        opMontantSansMarge();
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


        //vérifie si le client à un compte marge
        private bool verifCompteMarge()
        {
            try
            {
                //requête
                string verifMarge = "SELECT * FROM marge WHERE codecli = @codecli";
                commande = new SqlCommand(verifMarge, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur lit c'est que le client possède un compte hypo
                if (lecteur.Read())
                {
                    return true;
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

        //vérifie si ce code est associé à un client
        private bool verifClient()
        {
            try
            {
                //requête
                string verifClient = "SELECT * FROM clients WHERE codecli = @codecli";
                commande = new SqlCommand(verifClient, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur lit le client existe
                if (lecteur.Read())
                {
                    //on fait rien
                    return true;
                }
                //le client n'Existe pas
                else
                {
                    MessageBox.Show("Ce code n'est pas associé à un client, veuillez saisir un autre code.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
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


        //vérifie si le client à un compte hypothécaire
        private bool verifCompteHypo()
        {
            try
            {
                //requête
                string verifHypo = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(verifHypo, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur retourne c'est qu'il possède un compte épargne
                if (lecteur.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ce client ne possède pas de compte hypothécaire, veuillez saisir un autre code de client.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
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

        //vérifie si le montant est plus grand que dans le compte hypothécaire
        private void opMontantAvcMarge()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            decimal montantCompte;
            decimal difference = 0;
            try
            {
                //requête
                string verifMontant = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(verifMontant, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //le client possède un compte hypo
                if (lecteur.Read())
                {
                    decimal.TryParse(lecteur["montant"].ToString(), out montantCompte);
                    //si le montant saisie est plus grand que le montant compte
                    if(montantsaisie > montantCompte)
                    {
                        //on ferme la connexion
                        connexion.Close();
                        difference = montantsaisie - montantCompte;

                        //on met à 0 le compte hypothécaire
                       videCompte();

                        //requête pour ajouter la différence à la marge de crédit
                        string ajoutMarge = "UPDATE marge SET montant = montant + @diff WHERE codecli = @codecli";
                        commande = new SqlCommand(ajoutMarge, connexion);
                        commande.Parameters.AddWithValue("@diff", difference);
                        commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                        //ouverture de connexion
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        MessageBox.Show($"Vous avez prélevé " + montantCompte + "$ du compte hypothécaire et la marge de crédit du client a augmenté de " + difference + "$.", "Information", MessageBoxButton.OK, MessageBoxImage.None);
                        connexion.Close(); 
                    }
                    //sinon on update le compte sans toucher à la marge
                    else
                    {
                        //on ferme la connexion
                        connexion.Close();
                        updateHypo();
                    }
                }
                //le client ne possède pas de compte hypo
                else
                {
                    MessageBox.Show("Ce client ne possède pas de compte hypothécaire.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }

        //vérifie si le montant est plus grand que dans le compte hypothécaire
        private void opMontantSansMarge()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            decimal montantCompte = 0;
            try
            {
                //requête
                string verifMontant = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(verifMontant, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //le client possède un compte hypo
                if (lecteur.Read())
                {
                    decimal.TryParse(lecteur["montant"].ToString(), out montantCompte);
                    //si le montant saisie est plus grand que le montant compte
                    if (montantsaisie > montantCompte)
                    {
                        MessageBox.Show("Ce client n'a pas assez de fonds pour cette transaction, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    //sinon on update le compte sans toucher à la marge
                    else
                    {
                        updateHypo();
                    }
                }
                //le client ne possède pas de compte hypo
                else
                {
                    MessageBox.Show("Ce client ne possède pas de compte hypothécaire.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
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

        //pour updater le compte normalement
        private void updateHypo()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            try
            {
                //requête
                string update = "UPDATE hypothecaires SET montant = montant - @montant WHERE codecli = @codecli";
                commande = new SqlCommand(update, connexion);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
                MessageBox.Show($"Le montant de " + montantsaisie + "$ a été prélevé du compte hypothécaire.", "Information", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour vider le compte hypo lorsque on retire plus que ce qu'il contient
        private void videCompte()
        {
            try
            {
                //requête
                string vider = "UPDATE hypothecaires SET montant = 0 WHERE codecli = @codecli";
                commande = new SqlCommand(vider, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }

        // pour limiter l'entrée à des valeurs numériques et 2 chiffres après la virgule
        private void txtMontant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre ou un point
            Regex regex = new Regex(@"^[0-9]*\.?[0-9]{0,2}$");
            string newText = (sender as TextBox).Text + e.Text;

            // Vérifie si le texte complet est valide
            e.Handled = !regex.IsMatch(newText);
        }

        //pour limiter à seulement des chiffres sans point
        private void txtEntree_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //pour revenir au menu
        private void btnMenu_click(object sender, RoutedEventArgs e)
        {
            //on ramène au menu et envoit le client
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
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
