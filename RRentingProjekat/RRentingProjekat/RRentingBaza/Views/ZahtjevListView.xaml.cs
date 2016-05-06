using RRentingProjekat.RRentingBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace RRentingProjekat.RRentingBaza.Views
{
    public sealed partial class ZahtjevListView : Page
    {
        public ZahtjevListView()
        {
            this.InitializeComponent();
        }
        //pri load event povuci sve restorane i povezati ih sa list view
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                ZahtjeviIS.ItemsSource = db.Zahtjevi.OrderBy(c => c.nazivZahtjeva).ToList();
            }
        }
        //Event dodavanja novog Restorana
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                var contact = new Zahtjev
                {
                    nazivZahtjeva = NazivInput.Text,
                    brojSobe = Convert.ToInt32(SobaInput.Text),
                    obavljenZahtjev = Convert.ToBoolean(ObavljenInput.Text)
                };
                db.Zahtjevi.Add(contact);
                //SaveChanges obavezno da se reflektuju izmjene u bazi, tek tada dolazi do komunikacije s bazom
                db.SaveChanges();
                //reset polja za unos
                NazivInput.Text = string.Empty;
                SobaInput.Text = string.Empty;
                ObavljenInput.Text = string.Empty;

                //refresh liste restorana
                ZahtjeviIS.ItemsSource = db.Zahtjevi.OrderBy(c => c.nazivZahtjeva.ToList());
            }
        }
        //event za upload slike
        /*   private async void buttonUpload_Click(object sender, RoutedEventArgs e)
           {
               FileOpenPicker openPicker = new Windows.Storage.Pickers.FileOpenPicker();
               openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
               openPicker.SuggestedStartLocation =
              Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
               //Da se filtriraju dokumenti u pickeru na slike
               openPicker.FileTypeFilter.Add(".jpg");
               openPicker.FileTypeFilter.Add(".jpeg");
               openPicker.FileTypeFilter.Add(".png");
               //Prebacivanje contenta fajla u uploadSlika varijablu
               StorageFile file = await openPicker.PickSingleFileAsync();
               if (file != null)
               {
                   uploadSlika = (await Windows.Storage.FileIO.ReadBufferAsync(file)).ToArray(); ;
                   //Da se na buttonu vidi neka promjena da je upload uspjesan
                   buttonUpload.Content = "Picked photo: " + file.Name;
               } 
           } */
        //Event za brisanje restorana
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
                db.Zahtjevi.Remove((Zahtjev)ZahtjeviIS.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save
                db.SaveChanges();
                //Refresh liste restorana
                ZahtjeviIS.ItemsSource = db.Zahtjevi.OrderBy(c => c.nazivZahtjeva).ToList();
            }
        }


    }
}
