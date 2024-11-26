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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour LogginAdmin.xaml
    /// </summary>
    public partial class LogginAdmin : Window
    {
        SqlConnection connexion;
        SqlCommand commande;
        public LogginAdmin()
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
        }

        private void btnOk_click(object sender, RoutedEventArgs e)
        {
            try
            {
                verifstatutCompte();

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



        //si le compte n'est pas bloqué on accède à l'application
        private void verifstatutCompte()
        {
            try
            {
                string statut = "SELECT * FROM administrateurs WHERE idadmin = @idadmin AND nipadmin = @nipadmin";
                //création de l'objet sqlcommand
                commande = new SqlCommand(statut, connexion);
                commande.Parameters.AddWithValue("@idadmin", txtCodeAdmin.Text);
                commande.Parameters.AddWithValue("@nipadmin", txtNipAdmin.Password);

                //on ouvre la connexion
                connexion.Open();
                //on exécute la commande
                SqlDataReader lecteur2 = commande.ExecuteReader();
                // si le compte existe on ouvre le prochain form
                if (lecteur2.Read())
                {
                    MessageBox.Show("Bienvenue!", "Authentification réussie", MessageBoxButton.OK);
                    //on ouvre le prochain form
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Show();
                    this.Close();
                }
                //sinon il n'existe pas
                else
                {
                    MessageBox.Show("Ces informations sont incorrectes", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
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

        private void btnQuitter_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application?", "Avertissement", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Fermeture de l'application.");
                this.Close();
            }
        }

        private void btnRetour_click(object sender, RoutedEventArgs e)
        {
            frmLoggin frmloggin = new frmLoggin();
            frmloggin.Show();
            this.Close();
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
