using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour DepotEpargne.xaml
    /// </summary>
    public partial class DepotEpargne : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        SqlConnection connexion;
        SqlCommand commande;
        public DepotEpargne(ClientActif client)
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
            this.client = client;
        }

        // pour limiter l'entrée à des valeurs numériques et 2 chiffres après la virgule
        private void txtMontant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre ou un point
            Regex regex = new Regex(@"^[0-9]*\.?[0-9]{0,2}$");
            string newText = (sender as TextBox).Text + e.Text;

            // Vérifie si le texte complet est valide
            e.Handled = !regex.IsMatch(newText);
        }

        private void btnDeposerEpargne_click(object sender, RoutedEventArgs e)
        {
            var ajout = txtMontant.Text;
            try
            {
                //la requête
                string depot = "UPDATE epargnes SET montant = montant + @ajout WHERE codecli = @codecli";
                commande = new SqlCommand(depot, connexion);
                commande.Parameters.AddWithValue("@ajout", ajout);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de la connexion
                connexion.Open();
                //reader
                int ligneAffectee = commande.ExecuteNonQuery();

                if (ligneAffectee > 0)
                {
                    //on ferme la première connexion
                    connexion.Close();
                    //on sauvegarde la transaction
                    sauvegardeTransDepotEpa();
                    //message de succès
                    MessageBox.Show("Dépot effectué avec succès!", "Argent déposé", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("ERREUR");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez entrer que des valeurs numériques avec un maximum de deux chiffres après le point.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                connexion.Close();
            }
        }

        private void sauvegardeTransDepotEpa()
        {
            try
            {
                //requête
                string ajouttransac = "INSERT INTO transactions(codecli, typetransac,comptetransac,montant) VALUES (@codecli,'Dépot','Épargne',@montant)";
                commande = new SqlCommand(ajouttransac, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                commande.Parameters.AddWithValue("@montant", txtMontant.Text);
                //ouverture de connexion
                connexion.Open();
                //reader
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

        private void btnMenu_click(object sender, RoutedEventArgs e)
        {
            //on ramène au menu et envoit le client
            MenuPrincipal menuprinc = new MenuPrincipal(client);
            menuprinc.Show();
            //on ferme le premier form
            this.Close();
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
