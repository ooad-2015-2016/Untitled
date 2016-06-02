using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.Views;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Core;
using RRentingProjekat.RRentingBaza.ViewModels;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RezervacijaView : Page
    {
       
        public RezervacijaView()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (RezervacijaViewModel)e.Parameter;
        }

        private void buttonCijena_Click(object sender, RoutedEventArgs e)
        {
            int cijena= Odlazak.Date.Year + Odlazak.Date.Month + Odlazak.Date.Day - (Dolazak.Date.Year + Dolazak.Date.Month + Dolazak.Date.Day) * Convert.ToInt32(BrojDjeceInput.Text)/2 * Convert.ToInt32(BrojOdraslihInput.Text) ;
            textBoxCijena.Text = cijena + "KM";
        }
    }

}
