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
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        //récupère le client
        public ClientActif client {  get; set; }
        public MenuPrincipal(ClientActif client)
        {
            InitializeComponent();
            this.client = client;
            txtNomClient.Content = (client.prenom + "\n" + client.nom).ToString();
        }


        //ouvre le form de dépot
        private void btnDepot_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le prochain formulaire et envoit le client
            Depotfrm depotfrm = new Depotfrm(client);
            depotfrm.Show();
            //on ferme le premier form
            this.Close();
        }

        
        //ouvre le form de retrait
        private void btnRetrait_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le prochain formulaire et envoit le client
            Retraitfrm retraitfrm = new Retraitfrm(client);
            retraitfrm.Show();
            //on ferme le premier form
            this.Close();
        }

        //pour le form de transfert
        private void btnTransfert_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le prochain formulaire et envoit le client
            Transfertfrm transfertfrm = new Transfertfrm(client);
            transfertfrm.Show();
            //on ferme le premier form
            this.Close();
        }

        //pour le form de paiement
        private void btnPaiement_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le prochain formulaire et envoit le client
            Paiementfrm paiementfrm = new Paiementfrm(client);
            paiementfrm.Show();
            //on ferme le premier form
            this.Close();
        }

        //pour le form d'Affichage des soldes
        private void btnAfficherSoldes_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le prochain formulaire et envoit le client
            AfficherSoldesfrm afficherSoldesfrm = new AfficherSoldesfrm(client);
            afficherSoldesfrm.Show();
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
