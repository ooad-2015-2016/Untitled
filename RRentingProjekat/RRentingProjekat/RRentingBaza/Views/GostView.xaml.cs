using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RRentingProjekat.RRentingBaza.DataSource;

namespace RRentingProjekat.RRentingBaza.Views
{
    public sealed partial class GostView : Page
    {
        public GostView()
        {
            this.InitializeComponent();

            //inicijalizacija data source
            var inicijalizacija = new DataSourceRRenting();

            //staviti da se vidi back
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }



        //asinhrona metoda za provjeru da li je kliknut neki zahtjev
        private async void buttonZahtjev_Click (object sender, RoutedEventArgs e)
        {
            var Ime = ImePrezime.Text;
            var soba = BrojSobe.Text;
           
        }

        private async void buttonOcijeni_Click(object sender, RoutedEventArgs e)
        {
            var Ime = ImePrezime.Text;
            var soba = BrojSobe.Text;
        }

        

    }
}
