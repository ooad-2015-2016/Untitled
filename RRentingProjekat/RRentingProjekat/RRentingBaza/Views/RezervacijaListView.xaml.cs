using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.Views;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Core;
using RRentingProjekat.RRentingBaza.ViewModels;
using Windows.UI.Xaml;
using System.Linq;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RezervacijaListView : Page
    {
        public RezervacijaListView()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }
        //pri load event povuci sve rezervacije i povezati ih sa list view
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                RezervacijeIS.ItemsSource = db.Rezervacije.OrderBy(c => c.cijena).ToList();
            }
        }
      

        //Event za brisanje rezervacija
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
                db.Rezervacije.Remove((Rezervacija)RezervacijeIS.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save
                db.SaveChanges();
                //Refresh liste restorana
                RezervacijeIS.ItemsSource = db.Rezervacije.OrderBy(c => c.cijena).ToList();
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
            DataContext = (RezervacijaViewModel)e.Parameter;
        }

    }

}

