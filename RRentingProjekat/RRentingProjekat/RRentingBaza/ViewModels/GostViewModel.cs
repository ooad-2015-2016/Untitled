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

        public string Poruka { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajZahtjev{ get; set; }
        public ICommand OcijeniRRenting { get; set; }
        public ICommand Izlaz { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PrijavaViewModel Parent { get; set; } //Dodano

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public GostViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();
            this.Parent = parent;

            DodajZahtjev = new RelayCommand<object>(dodajZahtjev);
            OcijeniRRenting = new RelayCommand<object>(dodajStatistiku);
            Izlaz = new RelayCommand<object>(izlaz);
        }

        private void dodajZahtjev(object parametar)
        {
            NavigationServis.Navigate(typeof(ZahtjeviView), new ZahtjevViewModel(this));
        }

        private void dodajStatistiku(object parametar)
        {

        }

        private void izlaz(object parametar)
        {
            Application.Current.Exit();
        }
    }
}
