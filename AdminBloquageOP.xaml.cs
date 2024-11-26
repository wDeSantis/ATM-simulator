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
    /// Logique d'interaction pour AdminBloquageOP.xaml
    /// </summary>
    public partial class AdminBloquageOP : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminBloquageOP()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        //lorsqu'on clique sur le bouton bloquer
        private void btnBloquer_click(object sender, RoutedEventArgs e)
        {
            bloquerCompte();
        }

        //lorsqu'on clique sur le bouton débloquer
        private void btnDebloquer_click(Object sender, RoutedEventArgs e)
        {
            debloquerCompte();
        }

        //pour bloquer le compte
        private void bloquerCompte()
        {
            try
            {
                //requête
                string bloquer = "UPDATE clients SET bloque = 1 WHERE codecli = @codecli";
                commande = new SqlCommand(bloquer, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if(ligneAffectee > 0)
                {
                    MessageBox.Show("Client bloqué.", "Opération réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Aucun client n'est associé à ce code.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Aucun client n'est associé à ce code.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour débloquer le compte
        private void debloquerCompte()
        {
            try
            {
                //requête
                string bloquer = "UPDATE clients SET bloque = 0 WHERE codecli = @codecli";
                commande = new SqlCommand(bloquer, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                int ligneAffectee = commande.ExecuteNonQuery();

                if (ligneAffectee > 0)
                {
                    MessageBox.Show("Client débloqué.", "Opération réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Aucun client n'est associé à ce code.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aucun client n'est associé à ce code.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
