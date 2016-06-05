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

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class RecepcionerViewModel
    {
        public ICommand DodajGost { get; set; }
        //public ICommand ObracunCijene { get; set; }
        public ICommand StatusSobe { get; set; }
        public ICommand IzvrsiUplatu { get; set; }
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
            //ObracunCijene = new RelayCommand<object>(obracunaj, mozeLiObracunati);
            StatusSobe = new RelayCommand<object>(status, mozeLiStatus);
            IzvrsiUplatu= new RelayCommand<object>(uplata, mozeLiUplata);

            this.Parent = parent;
        }
        public RecepcionerViewModel(Uplata u)
        {
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            //ObracunCijene = new RelayCommand<object>(obracunaj, mozeLiObracunati);
            StatusSobe = new RelayCommand<object>(status, mozeLiStatus);
            IzvrsiUplatu = new RelayCommand<object>(uplata, mozeLiUplata);
            this._uplata = u;
            if (posljednjeDodani != null) { if (_uplata != null) { posljednjeDodani.placeno = true; } }
            else { }

        }
        public RecepcionerViewModel(Rezervacija rvm)
        {
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            //ObracunCijene = new RelayCommand<object>(obracunaj, mozeLiObracunati);
            StatusSobe = new RelayCommand<object>(status, mozeLiStatus);
            IzvrsiUplatu = new RelayCommand<object>(uplata, mozeLiUplata);
            this.posljednjeDodani = rvm;
            if (posljednjeDodani != null) { if (_uplata != null) { posljednjeDodani.placeno = true; } }
            else { }

        }
        private void uplata(object parametar)
        {
            NavigationServis.Navigate(typeof(PlacanjeView), new PlacanjeViewModel());
        }
        public void dodajGosta(object parametar)
        {

            NavigationServis.Navigate(typeof(KorisnikListView), new KorisnikViewModel());
        }

     

        public void status(object parametar)
        {

        }

        public bool mozeLiDodati(object parametar)
        {
            return true;
        }
        public bool mozeLiObracunati(object parametar)
        {
            return true;
        }
        public bool mozeLiStatus(object parametar)
        {
            return true;
        }
        public bool mozeLiUplata(object parametar)
        {
            return true;
        }





    }
}