using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProjekatOOAD.RRentingBaza.Views;
using ProjekatOOAD.RRentingBaza.Models;

namespace ProjekatOOAD.RRentingBaza.Views
{
    public sealed partial class SobaListView : Page
    {
        //Potrebno je privremeno negdje staviti sliku koja se uploaduje
        private byte[] uploadSlika;
        public SobaListView()
        {
            this.InitializeComponent();
        }
        //pri load event povuci sve restorane i povezati ih sa list view
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new SobaDbContext())
            {
                SobeIS.ItemsSource = db.Sobe.OrderBy(c => c.CijenaSobe).ToList();
            }
        }
        //Event dodavanja nove Sobe
        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SobaDbContext())
            {
                var contact = new Soba
                {
                    CijenaSobe = (float)Convert.ToDouble(CijenaSobeInput.Text),
                    BrojKreveta = Convert.ToInt32(BrojKrevetaInput.Text),
                    SlikaSobe = uploadSlika
                };
                db.Sobe.Add(contact);
                //SaveChanges obavezno da se reflektuju izmjene u bazi, tek tada dolazi do komunikacije
               // sa bazom
            db.SaveChanges();
                //reset polja za unos
                CijenaSobeInput.Text = string.Empty;
                BrojKrevetaInput.Text = string.Empty;
                
                //refresh liste restorana
                SobeIS.ItemsSource = db.Sobe.OrderBy(c => c.CijenaSobe).ToList();
            }
        }
        //event za upload slike
        private async void buttonUpload_Click(object sender, RoutedEventArgs e)
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
        }
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
            using (var db = new SobaDbContext())
            {
                db.Sobe.Remove((Soba)SobeIS.ItemFromContainer(dep));
                //Nije jos obrisano dok nije Save
                db.SaveChanges();
                //Refresh liste restorana
                SobeIS.ItemsSource = db.Sobe.OrderBy(c => c.CijenaSobe).ToList();
            }
        }
        /*
        //Event za promjenu Rating vrijednosti
        private void Button_Click_Povecaj(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null)
                return;
            using (var db = new RestoranDbContext())
            {
                Restoran restoran = (Restoran)RestoraniIS.ItemFromContainer(dep);
                restoran.Rating += 1;
                //Oznaciti da je klasa modified da se pri save prepozna da treba uraditi update
                db.Entry(restoran).State = EntityState.Modified;
                db.SaveChanges();
                //refresh liste restorana
                RestoraniIS.ItemsSource = db.Restorani.OrderBy(c => c.Naziv).ToList();
            }
            */
        }
    }
