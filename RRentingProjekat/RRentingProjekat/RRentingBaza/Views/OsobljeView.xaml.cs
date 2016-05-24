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
    public sealed partial class OsobljeView : Page
    {
        public OsobljeView()
        {
            //inicijalizacija data source
            // var inicijalizacija = new DataSourceRRenting();

            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*using (var db = new RRentingDbContext())
            {
               
            }*/
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (OsobljeViewModel)e.Parameter;
        }
    }
}
