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
using RRentingProjekat.RRentingBaza.ViewModels;
using RRentingProjekat.RRentingBaza.DataSource;
using Windows.UI.Popups;


namespace RRentingProjekat.RRentingBaza.Views
{
    public sealed partial class ZahtjeviView : Page
    {
        public ZahtjeviView()
        {
            this.InitializeComponent();

            //inicijalizacija data source
            //var inicijalizacija = new DataSourceRRenting();

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

        private async void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            var cb1 = checkBox1.IsChecked;
            var cb2 = checkBox2.IsChecked;
            var cb3 = checkBox3.IsChecked;
            var cb4 = checkBox4.IsChecked;

            if (checkBox1.IsChecked == true || checkBox2.IsChecked == true || checkBox3.IsChecked == true || checkBox4.IsChecked == true)
            {
                //cekiran je bar jedan checkbox i zahtjev se moze dodati
                this.Frame.Navigate(typeof(ZahtjeviView), new ZahtjeviView());
            }
            else
            {
                var dialog = new MessageDialog("Niste oznacili ni jedan zahtjev.", "Neuspješno slanje zahtjeva");
                await dialog.ShowAsync();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (ZahtjevViewModel)e.Parameter;
        }
    }
}
