using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.DateTimeFormatting;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Projet_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutProjet : Page
    {
        public AjoutProjet()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            string titre = tbxTitre.Text;
            string datedebut = DateDebutPicker.SelectedDate.ToString();
            datedebut = datedebut.Substring(0,10);
            string description = tbxDescription.Text;
            int budget = Convert.ToInt32(tbxBudget.Text);
            int nbemploye = Convert.ToInt32(tbxEmploye.Text);
            double totalSalaire = Convert.ToDouble(tbxSalaire.Text);
            int idClient = Convert.ToInt32(tbxIdClient.Text);
            string statut = cbStatut.SelectedValue.ToString();


            Projet projet = new Projet(titre, datedebut, description, budget, nbemploye, totalSalaire, idClient, statut);

            SingletonProjet.getInstance().Ajout(projet);
           
            afficher();
        }

        private void afficher()
        {
            SingletonProjet.getInstance().getProjet();
        }
    }
}
