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
    public sealed partial class AjoutClient : Page
    {
        public AjoutClient()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {


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

            else {

                string nomClient = tbxNomClient.Text;
                string adresseClient = tbxAdresseClient.Text;
                string numeroTel = tbxTelephoneClient.Text;
                string emailClient = tbxEmailClient.Text;


            Client client = new Client(nomClient, adresseClient, numeroTel, emailClient);

            SingletonClient.getInstance().Ajout(client);

            afficher();
            }
        }

        private void afficher()
        {
            SingletonClient.getInstance().getClient();
        }

    }
}
