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
using Windows.UI.Popups;

namespace RRentingProjekat.RRentingBaza.Views
{
    public sealed partial class GostView : Page
    {
        public GostView()
        {
            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;


        }


        /* //asinhrona metoda za provjeru da li je kliknut neki zahtjev
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

     */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (GostViewModel)e.Parameter;
        }

        private void gps_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GPSView));
        }

        private void OcijeniRRenting_Click(object sender, RoutedEventArgs e)
        {
            stackp.Visibility = Visibility.Visible;
        }

        private async void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Hvala Vam na ocjeni!", "Ugodan boravak");
            await dialog.ShowAsync();
            stackp.Visibility = Visibility.Collapsed;
            OcijeniRRenting.Visibility = Visibility.Collapsed;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lbxOcjene.SelectedIndex = 4;
        }
    }
}
