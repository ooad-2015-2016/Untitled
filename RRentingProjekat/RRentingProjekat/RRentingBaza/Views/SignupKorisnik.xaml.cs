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
using RRentingProjekat.RRentingBaza.ViewModels;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignupKorisnik : Page
    {
        public SignupKorisnik()
        {
            this.InitializeComponent();

            //inicijalizacija data source
            //  var inicijalizacija = new DataSourceRRenting();

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

       

        //asinhrona metoda za provjeru prijave korisnika
        private void buttonSignup_Click(object sender, RoutedEventArgs e)
        {
            var korisnickoIme = txtImeS.Text;
            var korisnickoPrezime = txtPrezimeS.Text;
            var korisnickiEmail = txtEmailS.Text;
            var korisnickiTelefon = txtTelefonS.Text;
            var korisnickaAdresa = txtAdresaS.Text;
            var sifra = txtPasswordS.Password;


            //var korisnik = DataSourceRRenting.ProvjeraKorisnika(korisnickoIme, sifra);
            /* if (korisnik != null && korisnik.KorisnikId > 0)
             {
                 this.Frame.Navigate(typeof(MainPage), korisnik);
             }
             else
             {
                 var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");
                 await dialog.ShowAsync();
             }
             */
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (RegistracijaViewModel)e.Parameter;
        }
    }
}
