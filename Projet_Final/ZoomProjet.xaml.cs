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
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Projet_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ZoomProjet : Page
    {
        int index;

        Projet p;

        string ajout;

        string numpro;
        public ZoomProjet()
        {
            this.InitializeComponent();

            GridClientProjet.ItemsSource = SingletonClient.getInstance().getListe();
            GridEmployeProjet.ItemsSource = SingletonEmploye.getInstance().getListe();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;

            if (index >= 0)
            {
                p = SingletonProjet.getInstance().getListe()[index];

                tbxTitreProjet.Text = "Projet " + p.Titre;

                tbxNumeroProjet.Text = "Projet Numero: " + p.NumeroProjet;

                tbxDateDebut.Text = "Date de début: " + p.DateDebut;

                tbxDescription.Text = "Description: \n" + p.Description;

                tbxBudget.Text = "Budget: " + p.Budget;

                tbxTotalSalaire.Text = "Total Salaire: " + p.TotalSalaire;

                tbxStatutProjet.Text = "Statut: " + p.StatutProjet;

                SingletonClient.getInstance().getClientProjet(p.IdClient);

                SingletonEmploye.getInstance().getEmployeProjet(p.NumeroProjet);

            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SingletonProjet.getInstance().supprimer(index);
            this.Frame.Navigate(typeof(ListeProjet));
        }

        private void GridClientProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GridClientProjet.SelectedIndex;
            this.Frame.Navigate(typeof(ZoomClient), index);
        }

        private void GridEmployeProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GridEmployeProjet.SelectedIndex;
            this.Frame.Navigate(typeof(ZoomEmploye), index);
        }

        private void btAjouter_Click(object sender, RoutedEventArgs e)
        {
            ajout = tbxAjoutEmploye.Text;
            numpro = p.NumeroProjet;
            SingletonProjet.getInstance().CreateLien(ajout,numpro);
            this.Frame.Navigate(typeof(ListeProjet));
        }
    }
}
