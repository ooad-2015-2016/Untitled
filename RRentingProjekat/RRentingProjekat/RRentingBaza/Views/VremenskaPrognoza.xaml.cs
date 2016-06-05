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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using RRentingProjekat.RRentingBaza.Models;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VremenskaPrognoza : Page
    {
        public VremenskaPrognoza()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += ThisPage_BackRequested;
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RootObject myWeather = await Prognoza.GetWeather(20.0, 30.0);

            ResultTextBlock.Text = "Nalazite se u: " + myWeather.name + "\nTrenutna temperatura: " + myWeather.main.temp + "C\n\nStanje: " + myWeather.weather[0].description;
            string slika = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(slika, UriKind.Absolute));
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RootObject myWeather = await Prognoza.GetWeather(20.0, 30.0);

            ResultTextBlock.Text = "Nalazite se u: " + myWeather.name + "\nTrenutna temperatura: " + myWeather.main.temp + " C\n\nStanje: " + myWeather.weather[0].description;
            string slika = String.Format("http://openweathermap.org/img/w/{0}.png", myWeather.weather[0].icon);
            ResultImage.Source = new BitmapImage(new Uri(slika, UriKind.Absolute));
        }
    }
}
