using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.Views;
using Windows.Storage.Pickers;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RezervacijaView : Page
    {
        public RezervacijaView()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        //Event dodavanja novog Restorana
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                var contact = new Rezervacija
                {
                    brojOdraslih = Convert.ToInt32(BrojOdraslihInput.Text),
                    brojDjece = Convert.ToInt32(BrojDjeceInput.Text),
                    datumDolaska = Convert.ToDateTime(Dolazak.Date.Value),
                    datumOdlaska = Convert.ToDateTime(Odlazak.Date.Value),
                    parking = ParkingRB.IsChecked.Value,
                    ljubimac = LjubimacRB.IsChecked.Value,
                    dodatniKrevet = DodatnikrevetRB.IsChecked.Value,
                    cijena = 500,
                    nacinPlacanja = (NacinPlacanja)Enum.Parse(typeof(NacinPlacanja), NacinPlacanjaListBox.SelectedItem.ToString()),
                };
                db.Rezervacije.Add(contact);
                db.SaveChanges();
                //reset polja za unos
                BrojOdraslihInput.Text = string.Empty;
                BrojDjeceInput.Text = string.Empty;
                CijenaInput.Text = string.Empty;
                Dolazak.Date = DateTime.Now;
                Odlazak.Date = DateTime.Now;
                ParkingRB.IsChecked = false;
                LjubimacRB.IsChecked = false;
                DodatnikrevetRB.IsChecked = false;
                //refresh liste rezervacija
                //RezervacijeIS.ItemsSource = db.Rezervacije.OrderBy(c => c.cijena).ToList();
            }
        }

        //Event za brisanje rezervacija
       /* private void Button_Click_Delete(object sender, RoutedEventArgs e)
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
        }*/
    }

}
