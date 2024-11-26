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
    /// Logique d'interaction pour Transfertfrm.xaml
    /// </summary>
    public partial class Transfertfrm : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        public Transfertfrm(ClientActif client)
        {
            InitializeComponent();
            this.client = client;
        }

        //on ouvre le formulaire de transfert epargne
        private void btnTransfertEpa_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour transfert envoit le client
            TransfertEpargne transfertepargne = new TransfertEpargne(client);
            transfertepargne.Show();
            //on ferme le premier form
            this.Close();
        }

        //on ouvre le formulaire de transfert hypothecaire
        private void btnTransfertHypo_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour transfert et envoit le client
            TransfertHypothecaire transferthypo = new TransfertHypothecaire(client);
            transferthypo.Show();
            //on ferme le premier form
            this.Close();
        }

        //on ouvre le formulaire de transfert vers marge de crédit
        private void btnTransfertMarge_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour transfert et envoit le client
            TransfertMarge transfertmarge = new TransfertMarge(client);
            transfertmarge.Show();
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
