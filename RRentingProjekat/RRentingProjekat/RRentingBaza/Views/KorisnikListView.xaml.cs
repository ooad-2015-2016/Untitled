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
    public sealed partial class KorisnikListView : Page
    {

        public KorisnikListView()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                //KorisniciIS.ItemsSource = db.Korisnici.OrderBy(c => c.Ime).ToList();
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
                db.Korisnici.Add(contact);
                //SaveChanges obavezno da se reflektuju izmjene u bazi, tek tada dolazi do komunikacije
                // sa bazom
                db.SaveChanges();
                //reset polja za unos
                NazivInput.Text = string.Empty;
                TelefonInput.Text = string.Empty;
                RatingInput.Text = string.Empty;
                GeoDuzinaInput.Text = string.Empty;
                GeoSirinaInput.Text = string.Empty;
                KorisniciIS.ItemsSource = db.Korisnici.OrderBy(c => c.Ime).ToList();
            }

            Frame rezervacija = Window.Current.Content as Frame;
            rezervacija.Navigate(typeof (RezervacijaListView));
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
                db.Korisnici.Remove((Korisnik)KorisniciIS.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save
                db.SaveChanges();
                //Refresh liste restorana
                KorisniciIS.ItemsSource = db.Korisnici.OrderBy(c => c.Ime).ToList();
            }
        }

    }
}