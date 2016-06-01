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
using System.ComponentModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class OsobljeViewModel
    {
        public INavigacija NavigationServis { get; set; }
        public PrijavaViewModel Parent { get; set; }
        public Zahtjev Zahtjev_ { get; set; }
        public Soba Soba_ { get; set; }
        public int brojSobe_ { get; set; }
        public ICommand SpasiPromjene { get; set; }
        public ICommand PrikaziZahtjeve { get; set; }

        private List<String> listaSoba;
        public List<String> ListaSoba
        {
            get { return listaSoba; }
            set { OnPropertyChanged("ListaSoba");  listaSoba = value;  }
        }

        private String izabranaSoba;
        public String IzabranaSoba
        {
            get { return izabranaSoba; }
            set { OnPropertyChanged("IzabranaSoba"); izabranaSoba = value;  }
        }

        private int brojSobe;
        /*
        private List<String> listaZahtjevaSobe;
        public List<String> ListaZahtjevaSobe
        {
            get { return listaZahtjevaSobe; }
            set { OnPropertyChanged("ListaZahtjevaSobe"); listaZahtjevaSobe = value;  }
        }
        */
        private String izabraniZahtjevSobe;
        public String IzabraniZahtjevSobe
        {
            get { return izabraniZahtjevSobe; }
            set { OnPropertyChanged("IzabraniZahtjevSobe");  izabraniZahtjevSobe = value;  }
        }

        private Boolean obavljeno;
        public Boolean Obavljeno
        {
            get { return obavljeno; }
            set { obavljeno = value; OnPropertyChanged("Obavljeno"); }
        }

        Zahtjev IzvrsenZahtjev;
        public ObservableCollection<String> MyItemsSource { get; set;  }


        public OsobljeViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();
            this.Parent = parent;
            ListaSoba = new List<String>();
            MyItemsSource = new ObservableCollection<String>();

            using (var db = new RRentingDbContext())
            {
            
                foreach (Zahtjev z in db.Zahtjevi)
                {
                    if (z.obavljenZahtjev == false && !ListaSoba.Contains(z.brojSobe.ToString()))
                     ListaSoba.Add(z.brojSobe.ToString());
                }
            }

            PrikaziZahtjeve = new RelayCommand<object>(prikazListeZahtjeva);
            SpasiPromjene = new RelayCommand<object>(spasiPromjene, mozeLiUpdateovati);
        }

        private async void prikazListeZahtjeva(object parametar)
        {
            if (IzabranaSoba != null)
            {
               
                brojSobe = Convert.ToInt32(IzabranaSoba);
                var dialg = new MessageDialog("Izabrali ste sobu: " + brojSobe, "Obavijest");
                await dialg.ShowAsync();

                MyItemsSource.Clear();
                using (var db = new RRentingDbContext())
                {
                    foreach (Zahtjev z in db.Zahtjevi)
                    {
                        if (z.obavljenZahtjev == false && z.brojSobe == brojSobe)
                            MyItemsSource.Add(z.nazivZahtjeva);
                      
                    }
                }

                
                MyItemsSource.CollectionChanged += MyItemsSource_CollectionChanged;

            }
            else
            {
                var dialg = new MessageDialog("Niste izabrali broj sobe!","Obavijest");
                await dialg.ShowAsync();
            }
        }




        private async void spasiPromjene(object parametar)
        {
       
            if (Obavljeno)
            {
                using (var db = new RRentingDbContext())
                {
                    brojSobe = Convert.ToInt32(IzabranaSoba);
                    IzvrsenZahtjev = db.Zahtjevi.Where(x => x.obavljenZahtjev == false && x.brojSobe == brojSobe && x.nazivZahtjeva == IzabraniZahtjevSobe).FirstOrDefault();

                    // prvo uklanjam zahtjev iz baze 
                    db.Zahtjevi.Remove(IzvrsenZahtjev);
                    db.SaveChanges();

                    //zatim vracam taj zahtjev u bazu uz oznaku da je izvrsen
                    IzvrsenZahtjev.obavljenZahtjev = true;
                    db.Zahtjevi.Add(IzvrsenZahtjev);
                    db.SaveChanges();

                    var dialog = new MessageDialog("Obaviili ste zahtjev: "+ izabraniZahtjevSobe + " za sobu broj: " + IzabranaSoba + ".", "Obavijest");
                    await dialog.ShowAsync();

                    MyItemsSource.Clear();
                    MyItemsSource.CollectionChanged += MyItemsSource_CollectionChanged;

                }
            }
            else
            {
                var dialog = new MessageDialog("Niste izvršili nikakve izmjene!", "Obavijest");
                await dialog.ShowAsync();
            }
        }
        public bool mozeLiUpdateovati(object parametar)
        {
            return true;
        }

        void MyItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("MyItemsSource");
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
