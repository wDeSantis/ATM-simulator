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

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour AdminCompteOP.xaml
    /// </summary>
    public partial class AdminCompteOP : Window
    {
        public AdminCompteOP()
        {
            InitializeComponent();
        }

        //pour ouvrir le formulaire de création de compte
        private void btnCreerCompte_click(object sender, RoutedEventArgs e)
        {
            AdminCreerCompteOP adminCreerCompteOP = new AdminCreerCompteOP();
            adminCreerCompteOP.Show();
            this.Close();
        }

        //pour ouvrir le formulaire de bloquer/débloquer
        private void btnBloquer_click(object sender, RoutedEventArgs e)
        {
            AdminBloquageOP adminBloquageOP = new AdminBloquageOP();
            adminBloquageOP.Show();
            this.Close();
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
