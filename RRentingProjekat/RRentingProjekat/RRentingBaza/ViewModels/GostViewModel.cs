using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.Helper;
using System.Windows.Input;
using RRentingProjekat.RRentingBaza.Views;
using Windows.UI.Xaml;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class GostViewModel 
    {
        public Gost gost { get; set;  }
        public Soba soba { get; set;  }

        public INavigacija NavigationServis { get; set; }

        public ICommand Dodaj{ get; set; }
        public ICommand OcijeniRRenting { get; set; }
        public ICommand Izlaz { get; set; }

        public PrijavaViewModel Parent { get; set; } //Dodano


        public GostViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();
            

            Dodaj = new RelayCommand<object>(dodajZahtjev, mozeLiDodatiZahtjev);
            OcijeniRRenting = new RelayCommand<object>(dodajStatistiku, mozeLiOcijeniti);
            Izlaz = new RelayCommand<object>(izlaz, mozeLiIzaci);

            this.Parent = parent;
        }

        private void dodajZahtjev(object parametar)
        {
            NavigationServis.Navigate(typeof(ZahtjeviView), new ZahtjevViewModel(this));
        }

        private void dodajStatistiku(object parametar)
        {

        }

        public bool mozeLiDodatiZahtjev(object parametar)
        {
            return true;
        }
        public bool mozeLiOcijeniti(object parametar)
        {
            return true;
        }
        public bool mozeLiIzaci(object parametar)
        {
            return true;
        }
        private void izlaz(object parametar)
        {
            Application.Current.Exit();
        }
    }
}
