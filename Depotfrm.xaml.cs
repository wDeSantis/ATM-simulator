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
    /// Logique d'interaction pour Depotfrm.xaml
    /// </summary>
    
    public partial class Depotfrm : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        public Depotfrm(ClientActif client)
        {
            InitializeComponent();
            this.client = client;
        }




        private void btnQuitter_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application?", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Fermeture de l'application.");
                this.Close();
            }
        }

        private void btnMenu_click(object sender, RoutedEventArgs e)
        {
            //on ramène au menu et envoit le client
            MenuPrincipal menuprinc = new MenuPrincipal(client);
            menuprinc.Show();
            //on ferme le premier form
            this.Close();
        }


        private void btnCheque_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour dépot chèque et envoit le client
            DepotCheque depotCheque = new DepotCheque(client);
            depotCheque.Show();
            //on ferme le premier form
            this.Close();

        }

        private void btnEpargne_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour dépot épargne et envoit le client
            DepotEpargne depotEpargne = new DepotEpargne(client);
            depotEpargne.Show();
            //on ferme le premier form
            this.Close();

        }

        private void btnHypothecaire_click(object sender, RoutedEventArgs e)
        {
            //on ouvre le formulaire pour dépot hypothécaire et envoit le client
            DepotHypothecaire depotHypo = new DepotHypothecaire(client);
            depotHypo.Show();
            //on ferme le premier form
            this.Close();
        }


    }
}
