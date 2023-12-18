using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Projet_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ZoomEmploye : Page
    {
        int index;

        Employe emp;
        public ZoomEmploye()
        {
            this.InitializeComponent();
            //GridProjet_EmployeActif.ItemsSource = SingletonProjet.getInstance().getListe();
            //GridProjet_EmployeInactif.ItemsSource = SingletonProjet.getInstance().getListe();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;

            if (index >= 0)
            {
                emp = SingletonEmploye.getInstance().getListe()[index];

                GridProjet_EmployeActif.ItemsSource = SingletonProjet.getInstance().getProjet_EmployeActif(emp);

                GridProjet_EmployeInactif.ItemsSource = SingletonProjet2.getInstance().getProjet_EmployeInactif(emp);

                tbxMatriculeEmploye.Text = "Employe " + emp.MatriculeEmploye;

                tbxNomEmploye.Text = "Nom: " + emp.NomEmploye;

                tbxPrenomEmploye.Text = "Prenom: " + emp.PrenomEmploye;

                tbxDateNaissance.Text = "Date de naissance: " + emp.DateNaissance;

                tbxDateEmbauche.Text = "Date d'embauche: " + emp.DateEmbauche;

                tbxEmailEmploye.Text = "Courriel: " + emp.EmailEmploye;

                tbxAdresseEmploye.Text = "Adresse: " + emp.AdresseEmploye;

                tbxTauxHoraire.Text = "Taux: " + emp.TauxHoraire;

                tbxNbrHeure.Text = "Heures: " + emp.NbrHeure;

                tbxStatutEmploye.Text = "Statut: " + emp.StatutEmploye;


                try
                {
                    Uri image = new Uri(emp.UrlPhoto);
                    imgEmploye.Source = new BitmapImage(image);
                }
                catch { }

            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SingletonEmploye.getInstance().supprimer(index);
            this.Frame.Navigate(typeof(ListeEmploye));
        }

        private void GridProjet_EmployeActif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GridProjet_EmployeActif.SelectedIndex;
            this.Frame.Navigate(typeof(ZoomProjet), index);
        }

        private void GridProjet_EmployeInactif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GridProjet_EmployeInactif.SelectedIndex;
            this.Frame.Navigate(typeof(ZoomProjet2), index);
        }
    }
}
