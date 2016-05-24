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

namespace RRentingProjekat.RRentingBaza.ViewModels
{
    class RezervacijaViewModel
    {
        public Gost RegistrovaniGost {get; set; }
        public int Id { get; set; }
        public int BrojOdraslihInput { get; set; }
        public int BrojDjeceInput { get; set; }
        public DateTime Dolazak { get; set; }
        public DateTime Odlazak { get; set; }
        public Boolean ParkingRB { get; set; }
        public Boolean LjubimacRB { get; set; }
        public Boolean DodatnikrevetRB { get; set; }

        private static int m_Counter2 = 0;
        public float CijenaInput { get; set; }
        public NacinPlacanja NacinPlacanjaListBox { get; set; }

        public Rezervacija DodanaRezervacija { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajRezervaciju { get; set; }
        public RezervacijaViewModel(RegistracijaViewModel rvm)
        {
            RegistrovaniGost = rvm.RegistrovaniKorisnik;
            DodajRezervaciju = new RelayCommand<object>(rezervisi);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter2);

            BrojDjeceInput = 0;
            BrojOdraslihInput = 0;
            Dolazak = DateTime.Now;
            Odlazak = DateTime.Now;
            ParkingRB = false;
            LjubimacRB = false;
            DodatnikrevetRB = false;
            NacinPlacanjaListBox = NacinPlacanja.Gotovinsko;
            CijenaInput = 0;

        }
        private void rezervisi(object parametar)
        {
//            RegistrovaniKorisnik = new Gost(Id, txtIme, txtPrezime, txtTelefon, txtAdresa, txtPassword, txtEmail);
           // NavigationServis.Navigate(typeof(GostView), new GostViewModel());
            DodanaRezervacija.brojOdraslih = BrojOdraslihInput;
            DodanaRezervacija.brojDjece = BrojDjeceInput;
            DodanaRezervacija.datumDolaska = Dolazak;
            DodanaRezervacija.datumOdlaska = Odlazak;
            DodanaRezervacija.parking = ParkingRB;
            DodanaRezervacija.ljubimac = LjubimacRB;
            DodanaRezervacija.dodatniKrevet = DodatnikrevetRB;
            DodanaRezervacija.cijena = CijenaInput;
            DodanaRezervacija.nacinPlacanja = NacinPlacanjaListBox;



        }
    }
}
