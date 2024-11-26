using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Logique d'interaction pour AdminCreerCompteOP.xaml
    /// </summary>
    public partial class AdminCreerCompteOP : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminCreerCompteOP()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        //pour lorsqu'on clique sur le bouton chèque
        private void btnCheque_click(object sender, RoutedEventArgs e)
        {
            //si le client existe
            if(verifClient() == true)
            {
                //si aucun compte n'existe pour ce client
                if (verifCheque() == true)
                {
                    //alors on crée le compte 
                    creerCompteChe();
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

        //pour lorsqu'on clique sur le bouton épargne
        private void btnEpargne_click(object sender, RoutedEventArgs e)
        {
            //si le client existe
            if (verifClient() == true)
            {
                //si aucun compte n'existe pour ce client
                if (verifEpargne() == true)
                {
                    //si le client possède un compte chèque
                    if(clientPossedeCheque() == true)
                    {
                        //alors on crée le compte 
                        creerCompteEpa();
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

        //pour lorsqu'on clique sur le bouton marge
        private void btnMarge_click(object sender, RoutedEventArgs e)
        {
            //si le client existe
            if (verifClient() == true)
            {
                //si aucun compte n'existe pour ce client
                if (verifMarge() == true)
                {
                    //si le client possède un compte chèque
                    if(clientPossedeCheque() == true)
                    {
                        //alors on crée le compte 
                        creerCompteMarge();
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

        //pour lorsqu'on clique sur le bouton hypothécaire
        private void btnHypothecaire_click(object sender, RoutedEventArgs e)
        {
            //si le client existe
            if (verifClient() == true)
            {
                //si aucun compte n'existe pour ce client
                if (verifHypo() == true)
                {
                    if(clientPossedeCheque() == true)
                    {
                        //alors on crée le compte 
                        creerCompteHypo();
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

        //vérifie que le client à un compte chèque avant de créer d'autre types de compte
        private bool clientPossedeCheque()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM cheques WHERE codecli = @codecli";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur retourne quelque chose il possède un compte
                if(lecteur.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Le client doit posséder un compte chèque pour permettre d'avoir un autre type de compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Le client doit posséder un compte chèque pour permettre d'avoir un autre type de compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }

        //vérifie si ce code appartient à un client
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

                //si le lecteur lit c'est que le client existe
                if (lecteur.Read())
                {
                    return true;
                }
                //sinon il n'existe pas alors erreur
                else
                {
                    MessageBox.Show("Aucun client n'est associé à ce code, veuillez en saisir un autre.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Aucun client n'est associé à ce code, veuillez en saisir un autre.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }

        //vérifie si le client possède déja un compte de ce genre
        private bool verifCheque()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM cheques WHERE codecli = @codecli";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur retourne une valeur alors il y a déja un compte
                if(lecteur.Read())
                {
                    MessageBox.Show("Ce client possède déja un compte chèque, veuillez choisir un autre type de compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                //si le lecteur ne retourne rien, aucun compte de créer de ce type
                else
                {
                    return true;
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

        //vérifie si le client possède déja un compte de ce genre
        private bool verifEpargne()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM epargnes WHERE codecli = @codecli";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur retourne une valeur alors il y a déja un compte
                if (lecteur.Read())
                {
                    MessageBox.Show("Ce client possède déja un compte épargne, veuillez choisir un autre type de compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                //si le lecteur ne retourne rien, aucun compte de créer de ce type
                else
                {
                    return true;
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

        //vérifie si le client possède déja un compte de ce genre
        private bool verifMarge()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM marge WHERE codecli = @codecli";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur retourne une valeur alors il y a déja un compte
                if (lecteur.Read())
                {
                    MessageBox.Show("Ce client possède déja un compte marge de crédit, veuillez choisir un autre type de compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                //si le lecteur ne retourne rien, aucun compte de créer de ce type
                else
                {
                    return true;
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

        //vérifie si le client possède déja un compte de ce genre
        private bool verifHypo()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si le lecteur retourne une valeur alors il y a déja un compte
                if (lecteur.Read())
                {
                    MessageBox.Show("Ce client possède déja un compte hypothécaire, veuillez choisir un autre type de compte.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                //si le lecteur ne retourne rien, aucun compte de créer de ce type
                else
                {
                    return true;
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

        //créer le compte cheque
        private void creerCompteChe()
        {
            try
            {
                //requête
                string creer = "INSERT INTO cheques(idcompteche, codecli, montant) VALUES (@id, @codecli, @montant)";
                commande = new SqlCommand(creer, connexion);
                commande.Parameters.AddWithValue("@id", txtID.Text);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@montant", txtMontant.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if(ligneAffectee > 0)
                {
                    MessageBox.Show("Compte créer.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }

        //créer le compte épargne
        private void creerCompteEpa()
        {
            try
            {
                //requête
                string creer = "INSERT INTO epargnes(idcompteepa, codecli, montant) VALUES (@id, @codecli, @montant)";
                commande = new SqlCommand(creer, connexion);
                commande.Parameters.AddWithValue("@id", txtID.Text);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@montant", txtMontant.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if (ligneAffectee > 0)
                {
                    MessageBox.Show("Compte créer.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }

        //créer le compte marge
        private void creerCompteMarge()
        {
            try
            {
                //requête
                string creer = "INSERT INTO marge(codecli, montant) VALUES (@codecli, @montant)";
                commande = new SqlCommand(creer, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@montant", txtMontant.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if (ligneAffectee > 0)
                {
                    MessageBox.Show("Compte créer.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }

        //créer le compte hypothecaire
        private void creerCompteHypo()
        {
            try
            {
                //requête
                string creer = "INSERT INTO hypothecaires(idcomptehyp, codecli, montant) VALUES (@id, @codecli, @montant)";
                commande = new SqlCommand(creer, connexion);
                commande.Parameters.AddWithValue("@id", txtID.Text);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@montant", txtMontant.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if (ligneAffectee > 0)
                {
                    MessageBox.Show("Compte créer.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ce ID est déja associé à un client, veuillez en choisir un autre", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
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

        //pour limiter à seulement des chiffres sans point
        private void txtEntree_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
    }
}
