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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
    
        public Login()
        {
            this.InitializeComponent();
            
           
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

        private void btnLoginUposlenik_Click(object sender, RoutedEventArgs e)
        {
            var uposlenikID = txtID.Text;
            var korisnickiMail = txtUsername.Text;
            var sifra = txtPassword.Password;
/*
            var korisnik = DataSourceRRenting.ProvjeraKorisnika(korisnickiMail, sifra);
             if (korisnik != null && korisnik.KorisnikId > 0)
             {
                 this.Frame.Navigate(typeof(MainPage), korisnik);
             }
             else
             if (korisnik == null)
             {
                 var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");
                 await dialog.ShowAsync();
             }*/
             
             
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
            txtID.Visibility = Visibility.Visible;
            btnLoginUposlenik.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (PrijavaViewModel)e.Parameter;
        }

    }
}