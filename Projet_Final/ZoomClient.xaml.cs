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
    public sealed partial class ZoomClient : Page
    {
        int index;

        Client c;
        public ZoomClient()
        {
            this.InitializeComponent();
            GridProjet.ItemsSource = SingletonProjet.getInstance().getListe();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;

            if (index >= 0)
            {
                c = SingletonClient.getInstance().getListe()[index];

                SingletonProjet.getInstance().getProjetClient(c);

                tbxIdClient.Text = "Client No. " + c.IdClient;

                tbxNomClient.Text = "Nom: " + c.NomClient;

                tbxAdresseClient.Text = "Adresse: " + c.AdresseClient;

                tbxNumeroTel.Text = "Telephone: " + c.NumeroTel;

                tbxEmailClient.Text = "Email: " + c.EmailClient;

            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SingletonClient.getInstance().supprimer(index);
            this.Frame.Navigate(typeof(ListeClient));
        }

        private void btModify_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ModifyClient), index);
        }

        private void GridProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GridProjet.SelectedIndex;
            this.Frame.Navigate(typeof(ZoomProjet), index);
        }
    }
}
