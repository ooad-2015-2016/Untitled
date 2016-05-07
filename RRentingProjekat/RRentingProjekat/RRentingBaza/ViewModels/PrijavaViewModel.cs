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
    class PrijavaViewModel
    {

        public Korisnik PrijavljeniGost { get; set; }
        public Korisnik PrijavljeniSef { get; set; }
        public Korisnik PrijavljeniOsoblje { get; set; }
        public Korisnik PrijavljeniRecepcionier { get; set; }

        public string UnosMail { get; set; }
        public string UnosPass { get; set; }

        public ICommand LoginGost { get; set; }
        public ICommand LoginUposlenik { get; set; }
        public INavigacija NavigationServis { get; set; }



        public PrijavaViewModel()
        {
            NavigationServis = new NavigationService();
            PrijavljeniGost = new Gost();
            PrijavljeniSef = new Sef();
            PrijavljeniRecepcionier = new Recepcioner();
            PrijavljeniOsoblje = new Osoblje();

            UnosMail = "";
            UnosPass = "";

            LoginGost = new RelayCommand<object>(loginGost, mozeLiSePrijavitiGost);
            LoginUposlenik = new RelayCommand<object>(loginUposlenik, mozeLiSePrijavitiUposlenik);
        }

        public bool mozeLiSePrijavitiGost(object parametar)
        {
            //ovdje se moze dodati uslov ako je potrebno da se komanda ne izvrsi
            return true;
        }
        public bool mozeLiSePrijavitiUposlenik(object parametar)
        {
            //ovdje se moze dodati uslov ako je potrebno da se komanda ne izvrsi
            return true;
        }
        public void loginGost(object parametar)
        {
            using (var db = new RRentingDbContext())
            {
                PrijavljeniGost = db.Korisnici.Where(x => x.Email == UnosMail && x.Sifra == UnosPass).FirstOrDefault();

                if (PrijavljeniGost == null)
                { }
                else
                {
                    // NavigationServis.Navigate(typeof(), GostViewModel(this));
                }
            }
        }
        public void loginUposlenik(object paremetar)
        {
            using (var db = new RRentingDbContext())
            {
                PrijavljeniGost = db.Korisnici.Where(x => x.Email == UnosMail && x.Sifra == UnosPass).FirstOrDefault();


                if (PrijavljeniGost == null)
                { }
                else
                {

                    // NavigationServis.Navigate(typeof(), GostViewModel(this));

                }

            }
        }
    }
}
