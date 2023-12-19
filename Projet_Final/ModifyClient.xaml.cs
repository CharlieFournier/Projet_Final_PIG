using Microsoft.UI;
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
    public sealed partial class ModifyClient : Page
    {
        int index ;

        Client c;
        public ModifyClient()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;

            if (index >= 0)
            {
                c = SingletonClient.getInstance().getListe()[index];

                SingletonProjet.getInstance().getProjetClient(c);

                tbxIdClient.Text = "" + c.IdClient;

                tbxNomClient.Text = "" + c.NomClient;

                tbxAdresseClient.Text = "" + c.AdresseClient;

                tbxTelephoneClient.Text = "" + c.NumeroTel;

                tbxEmailClient.Text = "" + c.EmailClient;

                tbxIdClient.IsEnabled = false;

            }
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            int idClient;
            string nomCli;
            string adresseCli;
            string numTel;
            string emailCli;

            if (tbxNomClient.Text == "")
            {
                tbxNomClient.BorderBrush = new SolidColorBrush(Colors.Red);
                
            }

            else if (tbxAdresseClient.Text == "")
            {
                tbxAdresseClient.BorderBrush = new SolidColorBrush(Colors.Red);

            }

            else if (tbxTelephoneClient.Text == "")
            {
                tbxTelephoneClient.BorderBrush = new SolidColorBrush(Colors.Red);

            }

            else if (tbxEmailClient.Text == "")
            {
                tbxEmailClient.BorderBrush = new SolidColorBrush(Colors.Red);

            }

            else
            {
                idClient = Convert.ToInt32(tbxIdClient.Text);
                nomCli = tbxNomClient.Text;
                adresseCli = tbxAdresseClient.Text;
                numTel = tbxTelephoneClient.Text;
                emailCli = tbxEmailClient.Text;

                Client modify = new Client(idClient,nomCli, adresseCli, numTel, emailCli);

                SingletonClient.getInstance().update(modify, index);
                this.Frame.Navigate(typeof(ListeClient));
            }

        }
    }
}
