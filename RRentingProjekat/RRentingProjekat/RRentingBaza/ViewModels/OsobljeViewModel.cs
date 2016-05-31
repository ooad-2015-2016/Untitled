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

        private List<int> listaSoba;
        public List<int> ListaSoba
        {
            get { return listaSoba; }
            set { listaSoba = value; OnPropertyChanged("ListaSoba"); }
        }

        private int izabranaSoba;
        public int IzabranaSoba
        {
            get { return izabranaSoba; }
            set { izabranaSoba = value; OnPropertyChanged("IzabranaSoba"); }
        }

        private List<String> listaZahtjevaSobe;
        public List<String> ListaZahtjevaSobe
        {
            get { return listaZahtjevaSobe; }
            set { listaZahtjevaSobe = value; OnPropertyChanged("ListaZahtjevaSobe"); }
        }

        private String izabraniZahtjevSobe;
        public String IzabraniZahtjevSobe
        {
            get { return izabraniZahtjevSobe; }
            set { izabraniZahtjevSobe = value; OnPropertyChanged("IzabraniZahtjevSobe"); }
        }

        private Boolean obavljeno;
        public Boolean Obavljeno
        {
            get { return obavljeno; }
            set { obavljeno = value; OnPropertyChanged("Obavljeno"); }
        }

        Zahtjev IzvrsenZahtjev;





        public OsobljeViewModel(PrijavaViewModel parent)
        {
            NavigationServis = new NavigationService();
            this.Parent = parent;

            using (var db = new RRentingDbContext())
            {
            
                foreach (Zahtjev z in db.Zahtjevi.Where(z=>z.obavljenZahtjev == false))
                {
                    ListaSoba.Add(z.brojSobe);
                }
                IzabranaSoba = ListaSoba.LastOrDefault();

                ListaZahtjevaSobe = new List<string>();
                foreach(Zahtjev z in db.Zahtjevi.Where( x=> x.obavljenZahtjev == false && x.brojSobe == IzabranaSoba))
                {
                    ListaZahtjevaSobe.Add(z.nazivZahtjeva);
                }
                IzabraniZahtjevSobe = ListaZahtjevaSobe.FirstOrDefault();

                IzvrsenZahtjev = db.Zahtjevi.Where(x => x.obavljenZahtjev == false && x.brojSobe == IzabranaSoba).FirstOrDefault();


            }
            SpasiPromjene = new RelayCommand<object>(spasiPromjene, mozeLiUpdateovati);
        }

        private async void spasiPromjene(object parametar)
        {
            if (Obavljeno)
            {
                using (var db = new RRentingDbContext())
                {

                    db.Zahtjevi.Remove(IzvrsenZahtjev);
                    IzvrsenZahtjev.obavljenZahtjev = true;
                    db.Zahtjevi.Add(IzvrsenZahtjev);

                    db.SaveChanges();

                    var dialog = new MessageDialog("Izmjene su spašene!", "Obavijest");
                    await dialog.ShowAsync();

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
