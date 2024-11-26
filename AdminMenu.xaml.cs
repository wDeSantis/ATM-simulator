using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminMenu()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        //pour ouvrir le form de création de client
        private void btnClient_click(object sender, RoutedEventArgs e)
        {
            AdminClientOP adminClientOP = new AdminClientOP();
            adminClientOP.Show();
            this.Close();
        }

        //pour ouvrir le form des comptes
        private void btnCompte_click(object sender, RoutedEventArgs e)
        {
            AdminCompteOP adminCompteOP = new AdminCompteOP();
            adminCompteOP.Show();
            this.Close();
        }

        //pour ouvrir le form d'affichage des transac
        private void btnAfficherTransac_click(object sender, RoutedEventArgs e)
        {
            AdminAfficherTransacOP adminAfficherTransac = new AdminAfficherTransacOP();
            adminAfficherTransac.Show();
            this.Close();
        }

        //pour ouvrir le form du guichet
        private void btnGuichet_click(object sender, RoutedEventArgs e)
        {
            AdminGuichetOP adminGuichetOP = new AdminGuichetOP();
            adminGuichetOP.Show();
            this.Close();
        }

        //pour ouvrir le form de prelevage hypothecaire
        private void btnPrelever_click(object sender, RoutedEventArgs e)
        {
            AdminPreleverOP adminPreleverOP = new AdminPreleverOP();
            adminPreleverOP.Show();
            this.Close();
        }

        //bouton pour payer l'intérêt de 1% sur tout les comptes épargnes
        private void btnInteret_click(object sender, RoutedEventArgs e)
        {
            //si oui
            if (MessageBox.Show("Êtes-vous sûr de vouloir payer 1% d'intérêt à tous les comptes épargnes?", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //requête
                    string interet = "UPDATE epargnes SET montant = montant * 1.01";
                    commande = new SqlCommand(interet, connexion);
                    //ouverture de connexion
                    connexion.Open();
                    int ligneAffectee = commande.ExecuteNonQuery();
                    MessageBox.Show($"Intérêt appliqué, opération faite sur " + ligneAffectee + " comptes.", "Information", MessageBoxButton.OK, MessageBoxImage.None);
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
            else
            {
                return;
            }
        }

        //bouton pour augmenter la marge de 5% de tout les comptes
        private void btnMarge_click(object sender, RoutedEventArgs e)
        {
            //si oui
            if (MessageBox.Show("Êtes-vous sûr de vouloir augmenter de 5% le solde de toutes les marges de crédit?", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //requête
                    string interet = "UPDATE marge SET montant = montant * 1.05";
                    commande = new SqlCommand(interet, connexion);
                    //ouverture de connexion
                    connexion.Open();
                    int ligneAffectee = commande.ExecuteNonQuery();
                    MessageBox.Show($"Marge augmentée, opération faite sur " + ligneAffectee + " comptes.", "Information", MessageBoxButton.OK, MessageBoxImage.None);
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
            else
            {
                return;
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
    }
}
