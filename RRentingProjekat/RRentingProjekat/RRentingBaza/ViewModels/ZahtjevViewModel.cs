using RRentingProjekat.RRentingBaza.Helper;
using RRentingProjekat.RRentingBaza.Models;
using RRentingProjekat.RRentingBaza.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class ZahtjevViewModel : UserControl
    {
        Zahtjev zahtjev { get; set; }
        List<Zahtjev> listaZahtjeva { get; set; }
        Gost gost { get; set; }


        public string Poruka { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajZahtjev { get; set; }
        public ICommand Nazad { get; set; }

        private Boolean zahtjev1;
        public Boolean Zahtjev1
        {
            get { return zahtjev1; }
            set { zahtjev1 = value; OnPropertyChanged("Zahtjev1");  }
        }

        private Boolean zahtjev2;
        public Boolean Zahtjev2
        {
            get { return zahtjev2; }
            set { zahtjev2 = value; OnPropertyChanged("Zahtjev2"); }
        }

        private Boolean zahtjev3;
        public Boolean Zahtjev3
        {
            get { return zahtjev3; }
            set { zahtjev3 = value; OnPropertyChanged("Zahtjev3"); }
        }

        private Boolean zahtjev4;
        public Boolean Zahtjev4
        {
            get { return zahtjev4; }
            set { zahtjev4 = value; OnPropertyChanged("Zahtjev4"); }
        }

        public PrijavaViewModel ParentPrijava { get; set; }

        public ZahtjevViewModel(GostViewModel gostVM, PrijavaViewModel prijavaVM)
        {
            // DataContext = new ZahtjeviView();
            NavigationServis = new NavigationService();
            gost = gostVM.gost;
            this.ParentPrijava = prijavaVM;

            listaZahtjeva = new List<Zahtjev>();

            DodajZahtjev = new RelayCommand<object>(dodajZahtjeve);
            Nazad = new RelayCommand<object>(nazad);


        }

        private async void dodajZahtjeve(object parametar)
        {

            using (var db = new RRentingDbContext())
            {

                //soba = db.Sobe.Where(x => x.BrojSobe == gost.brojSobe).FirstOrDefault();

                //validacija
                if (Zahtjev1 == false && Zahtjev2 == false && Zahtjev3 == false && Zahtjev4 == false)
                {
                    Poruka = "Niste dodali ni jedan zahtjev.";
                    //       NotifyPropertyChanged("Poruka");
                    var d = new MessageDialog(Poruka, "Poruka");
                    await d.ShowAsync();
                }
                else
                {
                    if (Zahtjev1 == true)
                    {
                        zahtjev = new Zahtjev();
                        zahtjev.brojSobe = gost.brojSobe;
                        zahtjev.nazivZahtjeva = "Pospremanje sobe";
                        zahtjev.obavljenZahtjev = false;
                        listaZahtjeva.Add(zahtjev);
                    }
                    if (Zahtjev2 == true)
                    {
                        zahtjev = new Zahtjev();
                        zahtjev.brojSobe = gost.brojSobe;
                        zahtjev.nazivZahtjeva = "Promjena posteljine";
                        zahtjev.obavljenZahtjev = false;
                        listaZahtjeva.Add(zahtjev);
                    }
                    if (Zahtjev3 == true)
                    {
                        zahtjev = new Zahtjev();
                        zahtjev.brojSobe = gost.brojSobe; ;
                        zahtjev.nazivZahtjeva = "Bacanje otpada";
                        zahtjev.obavljenZahtjev = false;
                        listaZahtjeva.Add(zahtjev);
                    }
                    if (Zahtjev4 == true)
                    {
                        zahtjev = new Zahtjev();
                        zahtjev.brojSobe = gost.brojSobe;
                        zahtjev.nazivZahtjeva = "Servis";
                        zahtjev.obavljenZahtjev = false;
                        listaZahtjeva.Add(zahtjev);
                    }


                    foreach (Zahtjev z in listaZahtjeva)
                    {
                        db.Zahtjevi.Add(z);
                    }
                    db.SaveChanges();


                    var dialog = new MessageDialog("Zahtjevi su uspješno poslani za sobu" + gost.brojSobe + "!\nŽelimo Vam ugodan boravak!", "Poslani zahtjevi");
                    await dialog.ShowAsync();

                    //ovo dole nesto nece 
                     NavigationServis.Navigate(typeof(GostView), new GostViewModel(this.ParentPrijava));



                }

            }

        }


        private void nazad(object parametar)
        {
     
           // NavigationServis.Navigate(typeof(GostView), new GostViewModel());
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
