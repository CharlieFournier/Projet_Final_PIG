using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class AjoutProjet : Page
    {
        public AjoutProjet()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            int code = Convert.ToInt32(tbxCode.Text);
            string modele = tbxModele.Text;
            string meuble = tbxMeuble.Text;
            string categorie = cbCategorie.SelectedValue.ToString();
            string couleur = tbxCouleur.Text;
            int prix = Convert.ToInt32(tbxPrix.Text);


            Projet projet = new Projet(code, modele, meuble, categorie, couleur, prix);

            SingletonProjet.getInstance().Ajout(projet);

            afficher();
        }

        private void afficher()
        {
            SingletonProjet.getInstance().getMateriel();
        }
    }
}
