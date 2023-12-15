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
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            //mainFrame.Navigate(typeof(Page1));
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iListeProjet":
                    mainFrame.Navigate(typeof(ListeProjet));
                    break;
                case "iAjoutProjet":
                    mainFrame.Navigate(typeof(AjoutProjet));
                    break;
                case "iListeEmploye":
                    mainFrame.Navigate(typeof(ListeEmploye));
                    break;
                case "iAjoutEmploye":
                    mainFrame.Navigate(typeof(AjoutEmploye));
                    break;
                case "iListeClient":
                    mainFrame.Navigate(typeof(ListeClient));
                    break;
                case "iAjoutClient":
                    mainFrame.Navigate(typeof(AjoutClient));
                    break;
                default:
                    break;
            }
        }
    }
}
