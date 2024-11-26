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
using System.Data;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace guichetauto_projet
{
    /// <summary>
    /// Logique d'interaction pour AfficherSoldesfrm.xaml
    /// </summary>
    public partial class AfficherSoldesfrm : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        SqlConnection connexion;
        SqlCommand commande;
        public AfficherSoldesfrm(ClientActif client)
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
            this.client = client;
            //on affiche les soldes au chargement
            soldeCheque();
            soldeEpargne();
            soldeHypothecaire();
            soldeMarge();
        }

        //pour recevoir et afficher le solde chèque
        private void soldeCheque()
        {
            try
            {
                //requête
                string soldeCheque = "SELECT * FROM cheques WHERE codecli = @codecli";
                commande = new SqlCommand(soldeCheque, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if(lecteur.Read())
                {
                    txtCheque.Content = lecteur["montant"].ToString();
                }
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

        //pour recevoir et afficher le solde épargne
        private void soldeEpargne()
        {
            try
            {
                //requête
                string soldeCheque = "SELECT * FROM epargnes WHERE codecli = @codecli";
                commande = new SqlCommand(soldeCheque, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if (lecteur.Read())
                {
                    txtEpargne.Content = lecteur["montant"].ToString();
                }
                //sinon aucun compte
                else
                {
                    txtEpargne.Content = "X";
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

        //pour recevoir et afficher le solde hypothecaire
        private void soldeHypothecaire()
        {
            try
            {
                //requête
                string soldeCheque = "SELECT * FROM hypothecaires WHERE codecli = @codecli";
                commande = new SqlCommand(soldeCheque, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if (lecteur.Read())
                {
                    txtHypo.Content = lecteur["montant"].ToString();
                }
                //sinon aucun compte
                else
                {
                    txtHypo.Content = "X";
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

        //pour recevoir et afficher le solde du compte marge
        private void soldeMarge()
        {
            try
            {
                //requête
                string soldeCheque = "SELECT * FROM marge WHERE codecli = @codecli";
                commande = new SqlCommand(soldeCheque, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if (lecteur.Read())
                {
                    txtMarge.Content = lecteur["montant"].ToString();
                }
                //sinon aucun compte
                else
                {
                    txtMarge.Content = "X";
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
