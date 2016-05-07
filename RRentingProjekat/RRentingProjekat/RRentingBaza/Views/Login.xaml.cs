using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Popups;
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
using RRentingProjekat.RRentingBaza.DataSource;

namespace RRentingProjekat.RRentingBaza.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();

            //inicijalizacija data source
            var inicijalizacija = new DataSourceRRenting();
            listStatus.Visibility = Visibility.Collapsed;
        }
        //asinhrona metoda za provjeru prijave korisnika


        private void btnLoginUposlenik_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var korisnickiMail = txtUsername.Text;
            var sifra = txtPassword.Password;

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

        private void checkStatus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}