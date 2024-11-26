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
    /// Logique d'interaction pour Paiementfrm.xaml
    /// </summary>
    public partial class Paiementfrm : Window
    {
        //récupère le client
        public ClientActif client { get; set; }
        SqlConnection connexion;
        SqlCommand commande;
        public Paiementfrm(ClientActif client)
        {
            connexion = new SqlConnection("server=.;initial catalog=GuichetAutoProjet;integrated security=true");
            InitializeComponent();
            this.client = client;
        }

        //pour payer la facture
        private void btnPaiement_click(object sender, RoutedEventArgs e)
        {
            try
            {
                //on vérifie si une facture existe
                if(verifFacture() == true)
                {
                    //si le montant n'est pas plus grand que le solde
                    if(verifSoldeFacture() == true)
                    {
                        //si on a les fonds nécéssaires dans le compte chèque
                        if(verifSoldeCheque() == true)
                        {
                            //on peut procéder
                            retirerCheque();
                            ajouterSoldeFacture();
                            sauvegarderTransactionPaiement();
                            MessageBox.Show("Paiement effectué, des frais de 1.25$ ont été prélevés du compte chèque.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            return;
                        } 
                    }
                    else
                    {
                        return;
                    } 
                }
                else
                {
                    return;
                } 
            }
            catch(Exception)
            {
                MessageBox.Show("ERREUR");
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour ajouter les fonds dans le solde de la facture
        private void ajouterSoldeFacture()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            try
            {
                //requête 
                string retirer = "UPDATE factures SET soldefacture = soldefacture - @montant WHERE codecli = @codecli";
                commande = new SqlCommand(retirer, connexion);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
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

        //pour retirer les fonds du compte chèque
        private void retirerCheque()
        {
            decimal montantsaisie = 0;
            decimal frais = 1.25m;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            montantsaisie += frais;
            try
            {
                //requête 
                string retirer = "UPDATE cheques SET montant = montant - @montant WHERE codecli = @codecli";
                commande = new SqlCommand(retirer, connexion);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
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

        //vérifier si la facture existe
        private bool verifFacture()
        {
            try
            {
                //requête
                string verif = "SELECT * FROM factures WHERE codecli = @codecli AND idfacture = @id";
                commande = new SqlCommand(verif, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                commande.Parameters.AddWithValue("@id", txtNumero.Text);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                //si une facture existe
                if (lecteur.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Aucune facture n'est associée à ce numéro.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour vérifier le solde du compte cheque
        private bool verifSoldeCheque()
        {
            decimal montantsaise = 0;
            decimal.TryParse(txtMontant.Text, out montantsaise);
            decimal solde = 0;
            decimal frais = 1.25m;
            try
            {
                //requête
                string verifSolde = "SELECT * FROM cheques WHERE codecli = @codecli";
                commande = new SqlCommand(verifSolde, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if (lecteur.Read())
                {
                    decimal.TryParse(lecteur["montant"].ToString(), out solde);
                    solde -= frais;

                    if (montantsaise > solde)
                    {
                        MessageBox.Show("Vous devez laisser au minimum 1.25$ dans votre compte pour les frais associés au paiement, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour vérifier le solde de la facture et ne pas payer plus que le nécéssaire
        private bool verifSoldeFacture()
        {
            decimal montantsaise = 0;
            decimal.TryParse(txtMontant.Text, out montantsaise);
            decimal solde = 0;
            try
            {
                //requête
                string verifSolde = "SELECT * FROM factures WHERE codecli = @codecli";
                commande = new SqlCommand(verifSolde, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                //ouverture de connexion
                connexion.Open();
                SqlDataReader lecteur = commande.ExecuteReader();

                if(lecteur.Read())
                {
                    decimal.TryParse(lecteur["soldefacture"].ToString(), out solde);

                    if(montantsaise > solde)
                    {
                        MessageBox.Show("Vous ne pouvez pas payer plus que le solde de la facture, veuillez réduire le montant.", "Attention!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connexion.Close();
            }
        }

        //pour sauvegarder l'opération
        private void sauvegarderTransactionPaiement()
        {
            decimal montantsaisie = 0;
            decimal.TryParse(txtMontant.Text, out montantsaisie);
            try
            {
                //requête
                string sauvegardertrans = "INSERT INTO transactions(codecli, typetransac, comptetransac, montant) VALUES (@codecli, 'Paiement', 'Chèque', @montant)";
                commande = new SqlCommand(sauvegardertrans, connexion);
                commande.Parameters.AddWithValue("@codecli", client.codecli);
                commande.Parameters.AddWithValue("@montant", montantsaisie);
                //ouverture de connexion
                connexion.Open();
                commande.ExecuteNonQuery();
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

        //pour limiter à seulement des chiffres
        private void txtMontant_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre ou un point
            Regex regex = new Regex(@"^\d*(\.\d{0,2})?$");

            // Récupère le texte actuel dans le TextBox
            var textBox = sender as TextBox;
            var newText = textBox.Text.Insert(textBox.CaretIndex, e.Text);

            // Vérifie si le nouveau texte correspond à l'expression régulière
            e.Handled = !regex.IsMatch(newText);
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
