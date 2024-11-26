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
    /// Logique d'interaction pour AdminGuichetOP.xaml
    /// </summary>
    public partial class AdminGuichetOP : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public AdminGuichetOP()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        //pour ajouter de l'argent papier
        private void btnAjouter_click(object sender, RoutedEventArgs e)
        {
            decimal montant = 0;
            decimal.TryParse(txtMontant.Text, out montant);
            try
            {
                //requête
                string ajout = "UPDATE guichets SET montant = montant + @montant WHERE idguichet = 1";
                commande = new SqlCommand(ajout, connexion);
                commande.Parameters.AddWithValue("@montant", txtMontant.Text);
                //ouverture de connexion
                connexion.Open();

                //si le montant est un multiple de 10 cest ok
                if(montant % 10 == 0)
                {
                    int ligneAffectee = commande.ExecuteNonQuery();

                    if (ligneAffectee > 0)
                    {
                        MessageBox.Show("Argent ajouté avec succès!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Le guichet ne peut pas posséder plus de 20000$, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                    }
                }
                //sinon erreur
                else
                {
                    MessageBox.Show("Veuillez saisir un multiple de 10 comme valeur.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Le guichet ne peut pas posséder plus de 20000$, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connexion.Close();
            }
        }



        //pour limiter à seulement des chiffres sans point
        private void txtEntree_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
