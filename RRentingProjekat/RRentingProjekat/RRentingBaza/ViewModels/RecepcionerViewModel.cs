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
        public ICommand ObracunCijene { get; set; }
        public ICommand StatusSobe { get; set; }
        public ICommand IzvrsiUplatu { get; set; }
        public INavigacija NavigationServis { get; set; }
        public Uplata _uplata { get; set; }

        public PrijavaViewModel Parent { get; set; }
        public PlacanjeViewModel NewParent { get; set; }

        public RecepcionerViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            ObracunCijene = new RelayCommand<object>(obracunaj, mozeLiObracunati);
            StatusSobe = new RelayCommand<object>(status, mozeLiStatus);
            IzvrsiUplatu= new RelayCommand<object>(uplata, mozeLiUplata);

            this.Parent = parent;
        }
        public RecepcionerViewModel(Uplata u)
        {
            NavigationServis = new NavigationService();

            DodajGost = new RelayCommand<object>(dodajGosta, mozeLiDodati);
            ObracunCijene = new RelayCommand<object>(obracunaj, mozeLiObracunati);
            StatusSobe = new RelayCommand<object>(status, mozeLiStatus);
            IzvrsiUplatu = new RelayCommand<object>(uplata, mozeLiUplata);
            this._uplata = u;

        }
        private async void uplata(object parametar)
        {
            NavigationServis.Navigate(typeof(PlacanjeView), new PlacanjeViewModel());
        }
        public void dodajGosta(object parametar)
        {

            NavigationServis.Navigate(typeof(KorisnikListView));
        }

        public void obracunaj(object parametar)
        {
           
        }

        public void statistika(object parametar)
        {

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