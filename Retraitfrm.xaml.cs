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

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour Retraitfrm.xaml
    /// </summary>
    public partial class Retraitfrm : Window
    {

        //récupère le client
        public ClientActif client { get; set; }
        public Retraitfrm(ClientActif client)
        {
            InitializeComponent();
            this.client = client;
        }

        //pour retrait cheque
        private void btnCheque_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour retrait chèque et envoit le client
            RetraitCheque retraitCheque = new RetraitCheque(client);
            retraitCheque.Show();
            //on ferme le premier form
            this.Close();
        }

        //pour retrait epargne
        private void btnEpargne_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour retrait chèque et envoit le client
            RetraitEpargne retraitEpargne = new RetraitEpargne(client);
            retraitEpargne.Show();
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

        // pour revenir au menu
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
