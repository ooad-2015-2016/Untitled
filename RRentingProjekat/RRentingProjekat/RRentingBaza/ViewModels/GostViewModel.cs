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
        public ICommand Izlaz { get; set; }

        public PrijavaViewModel Parent { get; set; }

        //statistika

        public const string MyListPropertyName = "lbxOcjene";
        public int izabranaOcjena { get; set; }
        private List<int> _myList = new List<int>() { 1, 2, 3, 4, 5 };

        public List<int> ocjene
        {
            get
            {
                return _myList;
            }

            set
            {
                if (_myList == value)
                {
                    return;
                }

                _myList = value;
            }
        }

        private ICommand _spremiOcjenu;

        public ICommand SpremiOcjenu
        {
            get
            {
                if (_spremiOcjenu == null)
                {
                    _spremiOcjenu = new RelayCommand<object>(
                        param => this.SaveObject(),
                        param => this.CanSave()
                    );
                }
                return _spremiOcjenu; ;
            }
        }
        

        private bool CanSave()
        {
            return true;
        }

        private void SaveObject()
        {
            Parent.PrijavljeniGost.ocjena = Convert.ToInt32(izabranaOcjena);
        }

        public GostViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();
            

            Dodaj = new RelayCommand<object>(dodajZahtjev, mozeLiDodatiZahtjev);
            Izlaz = new RelayCommand<object>(izlaz, mozeLiIzaci);
           
            this.Parent = parent;          
            
        }

        private void dodajZahtjev(object parametar)
        {
            
            NavigationServis.Navigate(typeof(ZahtjeviView), new ZahtjevViewModel(this));
        }

       
        public bool mozeLiDodatiZahtjev(object parametar)
        {
            return true;
        }
        
        public bool mozeLiIzaci(object parametar)
        {
            return true;
        }
        private void izlaz(object parametar)
        {
            NavigationServis.Navigate(typeof(Pocetna), new RRentingViewModel());
        }
    }
}
