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
    /// Logique d'interaction pour AdminClientOP.xaml
    /// </summary>
    public partial class AdminClientOP : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminClientOP()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        //pour créer le client
        private void btnCreer_click(object sender, RoutedEventArgs e)
        {
            creerClient();
        }

        //pour créer un client
        private void creerClient()
        {
            try
            {
                //requête
                string creerClient = "INSERT INTO clients(codecli, prenom, nom, telephone, courriel, nip, bloque) VALUES (@codecli, @prenom, @nom, @telephone, @courriel, @nip, 0)";
                commande = new SqlCommand(creerClient, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                commande.Parameters.AddWithValue("@prenom", txtPrenom.Text);
                commande.Parameters.AddWithValue("@nom", txtNom.Text);
                commande.Parameters.AddWithValue("@telephone", txtTelephone.Text);
                commande.Parameters.AddWithValue("@courriel", txtCourriel.Text);
                commande.Parameters.AddWithValue("@nip", txtNip.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if(ligneAffectee > 0)
                {
                    MessageBox.Show("Client créé!", "Opération réussie", MessageBoxButton.OK, MessageBoxImage.None);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ce code est déja associé à un client, veuillez en choisir un autre.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
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

        //pour seulement des lettres alphabetiques
        private void txtEntreeAlpha_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est une lettre alphabétique
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
