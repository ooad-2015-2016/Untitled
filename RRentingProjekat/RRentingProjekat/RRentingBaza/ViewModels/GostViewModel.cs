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
using System.Collections.ObjectModel;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class GostViewModel : INotifyPropertyChanged
    {
        public Gost gost { get; set;  }
        public Soba soba { get; set;  }

        public INavigacija NavigationServis { get; set; }

        public ICommand Dodaj{ get; set; }
        public ICommand Izlaz { get; set; }

        public PrijavaViewModel Parent { get; set; }


        //statistika   
        private List<int> _myList = new List<int>() { 1, 2, 3, 4, 5 };

        private List<int> ocjene;
        public List<int> Ocjene
        {
            get { return ocjene; }
            set { ocjene = value; OnPropertyChanged("Ocjene"); }
        }


        private int izabranaOcjena;
        public int IzabranaOcjena
        {
            get { return izabranaOcjena; }
            set
            {
                OnPropertyChanged("IzabranaOcjena");
                izabranaOcjena = value;
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
                OnPropertyChanged("SpremiOcjenu"); return _spremiOcjenu; 
            }
        }
        

        private bool CanSave()
        {
            return true;
        }

        private void SaveObject()
        {

            using (var db = new RRentingDbContext())
            {
                gost = db.Gosti.Where(x => x.Email == Parent.PrijavljeniGost.Email && x.Sifra == Parent.PrijavljeniGost.Sifra && x.SigurnosniID == 0).FirstOrDefault();

                if (gost != null)
                {
                    gost.dodijeliOcjenu(Convert.ToInt32(IzabranaOcjena));
                }
            }

            //update changes
            using (var rdb = new RRentingDbContext())
            {
                rdb.Entry(gost).State = Microsoft.Data.Entity.EntityState.Modified;

                rdb.SaveChanges();
            }
        }

        public GostViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();

            Ocjene = _myList;



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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
