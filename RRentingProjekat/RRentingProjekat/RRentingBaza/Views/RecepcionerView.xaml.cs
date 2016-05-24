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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecepcionerView : Page
    {
        public RecepcionerView()
        {
            this.InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void btnDodajGosta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void obracunCijene_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObracunCijene_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStatusSobe_Click(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (RecepcionerViewModel)e.Parameter;
        }
    }
}
