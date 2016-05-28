using RRentingProjekat.RRentingBaza.Helper;
using RRentingProjekat.RRentingBaza.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class ZahtjevViewModel : UserControl
    {
        Zahtjev zahtjev { get; set; }
        List<Zahtjev> listaZahtjeva { get; set; }
        Soba soba { get; set; }
        Gost gost { get; set; }


        public string Poruka { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajZahtjev { get; set; }
        public ICommand Nazad { get; set; }

       

        public ZahtjevViewModel(GostViewModel gostVM)
        {
           // DataContext = new ZahtjeviView();
            zahtjev = new Zahtjev();
            soba = gostVM.soba;
            gost = gostVM.gost;

            listaZahtjeva = new List<Zahtjev>();

            DodajZahtjev = new RelayCommand<object>(dodajZahtjev);
            Nazad = new RelayCommand<object>(nazad);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private void dodajZahtjev(object parametar)
        {
       
            //treba ispitati koji su checkboxovi chekirani i u skladu s tim te zahtjeve dodati u listView
            using (var db = new RRentingDbContext())
            {
                soba = db.Sobe.Where(x => x.BrojSobe == gost.brojSobe).FirstOrDefault();

                if (listaZahtjeva.Count == 0)
                {
                    Poruka = "Niste dodali ni jedan zahtjev.";
                    NotifyPropertyChanged("Poruka");
                }
                else
                {
                    Poruka = "Zahtjevi su poslani";
                    NotifyPropertyChanged("Poruka");
                    // kako proslijediti ovu listu zahtjeva osoblju?
                   // NavigationServis.Navigate(typeof(GostView), new GostViewModel());
                }
            }
        }

        private void nazad(object parametar)
        {
     
           // NavigationServis.Navigate(typeof(GostView), new GostViewModel());
        }

    }
}
