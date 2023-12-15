using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Projet_Final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutEmploye : Page
    {
        public AjoutEmploye()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            string nomEmploye = tbxNom.Text;
            string prenomEmploye = tbxPrenom.Text;
            string dateNaissance = DateNaissancePicker.SelectedDate.ToString();
            dateNaissance = dateNaissance.Substring(0, 10);
            string emailEmploye = tbxEmail.Text;
            string adresseEmploye = tbxAdresse.Text;
            string dateEmbauche = DateEmbauchePicker.SelectedDate.ToString();
            dateEmbauche = dateEmbauche.Substring(0, 10);
            double tauxHoraire = Convert.ToDouble(tbxTauxHoraire.Text);
            string urlPhoto = tbxPhoto.Text;
            string statut = cbStatut.SelectedValue.ToString();
            double nbrHeure = Convert.ToDouble(tbxHeures.Text);



            Employe employe = new Employe(nomEmploye, prenomEmploye, dateNaissance, emailEmploye, adresseEmploye, dateEmbauche, tauxHoraire, urlPhoto, statut, nbrHeure);

            SingletonEmploye.getInstance().Ajout(employe);

            afficher();
        }

        private void afficher()
        {
            SingletonEmploye.getInstance().getEmploye();
        }

    }
}
