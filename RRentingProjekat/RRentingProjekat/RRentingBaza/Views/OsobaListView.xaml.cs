using Microsoft.Data.Entity;
using RRentingProjekat.RRentingBaza.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace RRentingProjekat.RRentingBaza.Views
{
    public sealed partial class OsobeListView : Page
    {

        public OsobeListView()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                OsobeIS.ItemsSource = db.Osobe.OrderBy(c => c.Ime).ToList();
            }
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                var contact = new Gost
                {
                    Ime = NazivInput.Text,
                    Telefon = TelefonInput.Text,
                    Sifra = RatingInput.Text,
                    Adresa = GeoDuzinaInput.Text,
                    Prezime = GeoSirinaInput.Text,

                };
                db.Osobe.Add(contact);
                //SaveChanges obavezno da se reflektuju izmjene u bazi, tek tada dolazi do komunikacije
                // sa bazom
                db.SaveChanges();
                //reset polja za unos
                NazivInput.Text = string.Empty;
                TelefonInput.Text = string.Empty;
                RatingInput.Text = string.Empty;
                GeoDuzinaInput.Text = string.Empty;
                GeoSirinaInput.Text = string.Empty;
                OsobeIS.ItemsSource = db.Osobe.OrderBy(c => c.Ime).ToList();
            }
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
                db.Osobe.Remove((Osoba)OsobeIS.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save
                db.SaveChanges();
                //Refresh liste restorana
                OsobeIS.ItemsSource = db.Osobe.OrderBy(c => c.Ime).ToList();
            }
        }

    }
}