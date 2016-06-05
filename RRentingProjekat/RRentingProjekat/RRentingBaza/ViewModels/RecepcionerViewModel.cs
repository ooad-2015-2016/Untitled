using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;
using System.Windows.Input;
using Windows.UI.Xaml;
using RRentingProjekat.RRentingBaza.Helper;
using RRentingProjekat.RRentingBaza.Views;
using Windows.UI.Popups;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class RecepcionerViewModel
    {
        public ICommand DodajGost { get; set; }
        public ICommand IzvrsiUplatu { get; set; }
        public ICommand AzurirajSobe { get; set; }

        public INavigacija NavigationServis { get; set; }
        public Uplata _uplata { get; set; }
        public Rezervacija posljednjeDodani { get; set; }
        public PrijavaViewModel Parent { get; set; }
        public PlacanjeViewModel NewParent { get; set; }

        public RecepcionerViewModel(PrijavaViewModel parent)
        {
            posljednjeDodani = new Rezervacija();
            _uplata = new Uplata();
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            IzvrsiUplatu= new RelayCommand<object>(uplata, mozeLiUplata);
            AzurirajSobe = new RelayCommand<object>(sobe, moze);

            this.Parent = parent;
        }
        public RecepcionerViewModel(Uplata u)
        {
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            IzvrsiUplatu = new RelayCommand<object>(uplata, mozeLiUplata);
            AzurirajSobe = new RelayCommand<object>(sobe, moze);

            this._uplata = u;
            if (posljednjeDodani != null) { if (_uplata != null) { posljednjeDodani.placeno = true; } }
            else { }

        }
        public RecepcionerViewModel(Rezervacija rvm)
        {
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            IzvrsiUplatu = new RelayCommand<object>(uplata, mozeLiUplata);
            this.posljednjeDodani = rvm;
            if (posljednjeDodani != null) { if (_uplata != null) { posljednjeDodani.placeno = true; } }
            else { }
            AzurirajSobe = new RelayCommand<object>(sobe, moze);

        }

        private async void sobe(object parametar)
        {
            Boolean find = false;
            using (var db = new RRentingDbContext())
            {
                foreach (var g in db.Gosti)
                {
                    if ((g.datumOdlaska.Day + g.datumOdlaska.Year + g.datumOdlaska.Month) <= (DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day))
                    {

                        foreach (Soba s in DataSource.DataSourceRRenting.DajSveSobe())
                        {
                            if (g.brojSobe == s.BrojSobe)
                            {
                                s.Status = StatusSobe.Slobodna;
                                find = true;
                                var dialog = new MessageDialog("Ažurirali ste status rezervisanih soba u slobodne.");
                                await dialog.ShowAsync();
                                break;
                            }

                            if (find) break;
                        }

                    }
                }
            }
            if (!find)
            {
                var d = new MessageDialog("Podaci su već ažurirani.");
                await d.ShowAsync();

            }


        }
         


        private void uplata(object parametar)
        {
            NavigationServis.Navigate(typeof(PlacanjeView), new PlacanjeViewModel());
        }
        public void dodajGosta(object parametar)
        {

            NavigationServis.Navigate(typeof(KorisnikListView), new KorisnikViewModel());
        }


        public bool moze(object parametar)
        {
            return true;
        }

        public bool mozeLiDodati(object parametar)
        {
            return true;
        }
        public bool mozeLiObracunati(object parametar)
        {
            return true;
        }
       
        public bool mozeLiUplata(object parametar)
        {
            return true;
        }





    }
}