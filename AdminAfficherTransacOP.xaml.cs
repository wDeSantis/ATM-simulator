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
    /// Logique d'interaction pour AdminAfficherTransacOP.xaml
    /// </summary>
    public partial class AdminAfficherTransacOP : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminAfficherTransacOP()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        //pour récupérer les transactions et les chargers
        private void btnAfficher_click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> transactions = new List<string>();
                string id = "";
                string type = "";
                string compte = "";
                string montant = "";
                string transac = "";
                //requête
                string recup = "SELECT * FROM transactions WHERE codecli = @codecli";
                commande = new SqlCommand(recup, connexion);
                commande.Parameters.AddWithValue("@codecli", txtCodeCli.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si on récupère des valeurs c'est que le client à un historique de transactions
                if (lecteur.Read())
                {
                    //on les met dans la liste et les affiche
                    while (lecteur.Read())
                    {
                        id = lecteur["idtransac"].ToString();
                        type = lecteur["typetransac"].ToString();
                        compte = lecteur["comptetransac"].ToString();
                        montant = lecteur["montant"].ToString();
                        transac = $"" + id + ", " + type + " , " + compte + ", " + montant;
                        transactions.Add(transac);
                    }
                    lstTransac.ItemsSource = transactions;
                }
                //sinon aucune transaction
                else
                {
                    MessageBox.Show("Aucun code de ce type n'est associé à un client ayant fait des transactions dans leur comptes.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Aucun code de ce type n'est associé à un client ayant fait des transactions dans leur comptes.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
