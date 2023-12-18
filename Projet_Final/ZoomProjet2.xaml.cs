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
    public sealed partial class ZoomProjet2 : Page
    {
        int index;

        Projet p;
        public ZoomProjet2()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            index = (int)e.Parameter;

            if (index >= 0)
            {
                p = SingletonProjet2.getInstance().getListe()[index];

                tbxTitreProjet.Text = "Projet " + p.Titre;

                tbxNumeroProjet.Text = "Numero: " + p.NumeroProjet;

            }
        }

        private void btSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SingletonProjet2.getInstance().supprimer(index);
            this.Frame.Navigate(typeof(ListeProjet));
        }

    }
}
