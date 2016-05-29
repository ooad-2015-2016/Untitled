using Microsoft.Data.Entity;
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.ViewModels;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RRentingProjekat.RRentingBaza.Views
{
    public sealed partial class KorisnikListView : Page
    {
       

        public KorisnikListView()
        {
            this.InitializeComponent();

            //inicijalizacija data source
            //  var inicijalizacija = new DataSourceRRenting();

            //staviti da se vidi back
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                KorisniciIS.ItemsSource = db.Gosti.OrderBy(c => c.Prezime).ToList();
            }
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
            DataContext = (KorisnikViewModel)e.Parameter;
        }

       
            
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            //Dobavljanje objekta iz liste koji je kori[ten da se popuni red u listview
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            using (var db = new RRentingDbContext())
            {
                db.Gosti.Remove((Gost)KorisniciIS.ItemFromContainer(dep));
                db.SaveChanges();
                KorisniciIS.ItemsSource = db.Gosti.OrderBy(c => c.Ime).ToList();
            }
        }

    }
}