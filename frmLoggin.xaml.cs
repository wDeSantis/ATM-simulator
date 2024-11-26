using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour frmLoggin.xaml
    /// </summary>
    public partial class frmLoggin : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        int essaie = 0;
        public frmLoggin()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        private void btnOk_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //la requête pour select
                string authentification = "SELECT * FROM clients WHERE codecli = @codecli AND nip = @nip AND bloque = 0";
                //création de l'objet sqlcommand
                commande = new SqlCommand(authentification, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@nip", txtNipCli.Password);

                //ouverture de la connexion
                connexion.Open();
                //reader
                SqlDataReader lecteur = commande.ExecuteReader();

                //si on a une réponse (donc authentification ok)
                if (lecteur.Read())
                {
                    //on crée le client comme objet
                    ClientActif client = new ClientActif();
                    client.prenom = lecteur["prenom"].ToString();
                    client.nom = lecteur["nom"].ToString();
                    client.codecli = lecteur["codecli"].ToString();
                    client.nip = lecteur["nip"].ToString();
                    MessageBox.Show($"Bienvenue " + client.prenom + " " + client.nom, "Authentification", MessageBoxButton.OK, MessageBoxImage.Information);
                    //on ouvre le prochain formulaire et envoit le client
                    MenuPrincipal menuprin = new MenuPrincipal(client);
                    menuprin.Show();
                    //on ferme le premier form
                    this.Close();
                }
                else
                {
                    lecteur.Close();
                    connexion.Close();
                    // on vérifie si le compte est bloquer
                    verifstatutCompte();
                    //si on a échoué l'authentification 3 fois
                    //vérif si on essaie l'authentification sur un compte existant
                    compteexiste();
                    if (essaie == 3)
                    {
                        // on ferme le lecteur
                        lecteur.Close();
                        connexion.Close();
                        MessageBox.Show("Le compte à été bloqué vous devez contacter votre banque", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        //on bloque le compte
                        bloquerCompte();
                        //on remet à 0 essaie
                        essaie = 0;
                        //on ferme l'app
                        this.Close();
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexion.Close();
            }
        }

        private void bloquerCompte()
        {
            try
            {
                string bloquer = "UPDATE clients SET bloque = 1 WHERE codecli = @codecli";
                //création de l'objet sqlcommand
                commande = new SqlCommand(bloquer, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@nip", txtNipCli.Password);

                //on ouvre la connexion
                connexion.Open();
                //on exécute la commande
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


        //vérif si on fait un test de connexion sur un compte existant
        private void compteexiste()
        {
            try
            {
                string existe = "SELECT * FROM clients WHERE codecli = @codecli";
                //création de l'objet sqlcommand
                commande = new SqlCommand(existe, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //on ouvre la connexion
                connexion.Open();
                //on exécute la commande
                SqlDataReader lecteur3 = commande.ExecuteReader();
                //si le compte existe on incrémente les essaie
                if (lecteur3.Read())
                {
                    essaie++;
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


        //si le compte n'est pas bloqué on accède à l'application
        private void verifstatutCompte()
        {
            try
            {
                string statut = "SELECT * FROM clients WHERE codecli = @codecli AND nip = @nip AND bloque = 1";
                //création de l'objet sqlcommand
                commande = new SqlCommand(statut, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@nip", txtNipCli.Password);

                //on ouvre la connexion
                connexion.Open();
                //on exécute la commande
                SqlDataReader lecteur2 = commande.ExecuteReader();
                // si le compte existe et qu'il est bloqué
                if (lecteur2.Read())
                {
                    MessageBox.Show("Ce compte est bloqué, veuillez contacter votre banque", "Compte bloqué", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                }
                //sinon il n'existe pas
                else
                {
                    MessageBox.Show("Ces informations sont incorrectes", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void btnQuitter_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application?", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Fermeture de l'application.");
                this.Close();
            }
        }

        //pour ouvrir le form d'admin
        private void btnAdmin_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le prochain formulaire et envoit le client
            LogginAdmin logginAdmin = new LogginAdmin();
            logginAdmin.Show();
            //on ferme le premier form
            this.Close();
        }

        //pour limiter à seulement des chiffres sans point
        private void txtEntree_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
