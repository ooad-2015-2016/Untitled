using Microsoft.Data.Entity;
using RRentingProjekat.RRentingBaza.Models;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
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
            //this.Id = System.Threading.Interlocked.Increment(ref m_Counter2);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                KorisniciIS.ItemsSource = db.Gosti.OrderBy(c => c.Prezime).ToList();
            }
        }

        private async void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new RRentingDbContext())
            {
                //validacija
                if (NazivInput == null || TelefonInput == null || SifraInput == null || AdresaInput == null || PrezimeInput == null || EmailInput == null)
                {
                    var dialog = new MessageDialog("Unesite sve tražene podatke", "Neuspješna prijava");
                    await dialog.ShowAsync();
                }
                else if (NazivInput.Text.Length < 2 || PrezimeInput.Text.Length < 2 || AdresaInput.Text.Length < 3)
                {
                    var dialog = new MessageDialog("Prekratki su ime/prezime/adresa.", "Neuspješna prijava");
                    await dialog.ShowAsync();
                }
                else if (TelefonInput.Text.Length < 6)
                {
                    var dialog = new MessageDialog("Neispravan format telefona", "Neuspješna prijava");
                    await dialog.ShowAsync();
                }
                else if (SifraInput.Text.Length < 4 || !EmailInput.Text.Contains("@") || !EmailInput.Text.Contains("."))
                {

                    var dialog = new MessageDialog("Password je prekratak/Email nije ispravan.", "Neuspješna prijava");
                    await dialog.ShowAsync();
                }

                else
                {
                    var contact = new Gost (NazivInput.Text, PrezimeInput.Text, TelefonInput.Text, AdresaInput.Text, SifraInput.Text, EmailInput.Text, 0);
                   
                    db.Gosti.Add(contact);

                    db.SaveChanges();

                    //reset polja za unos
                    NazivInput.Text = string.Empty;
                    PrezimeInput.Text = string.Empty;
                    TelefonInput.Text = string.Empty;
                    SifraInput.Text = string.Empty;
                    AdresaInput.Text = string.Empty;
                    EmailInput.Text = string.Empty;
                    KorisniciIS.ItemsSource = db.Gosti.OrderBy(c => c.Ime).ToList();
                    
                }
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
                db.Gosti.Remove((Gost)KorisniciIS.ItemFromContainer(dep));
                db.SaveChanges();
                KorisniciIS.ItemsSource = db.Gosti.OrderBy(c => c.Ime).ToList();
            }
        }

    }
}