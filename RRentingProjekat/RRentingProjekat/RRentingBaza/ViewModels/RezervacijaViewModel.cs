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
        int BrojOdraslihInput;
        int BrojDjeceInput;
        DateTime Dolazak;
        DateTime Odlazak;
        Boolean ParkingRB;
        Boolean LjubimacRB;
        Boolean DodatnikrevetRB;
        private static int m_Counter2 = 0;
        float CijenaInput;
        NacinPlacanja NacinPlacanjaListBox;
        public Rezervacija DodanaRezervacija { get; set; }
        public INavigacija NavigationServis { get; set; }
        public ICommand DodajRezervaciju { get; set; }
        public RezervacijaViewModel(RegistracijaViewModel rvm)
        {
            RegistrovaniGost = rvm.RegistrovaniKorisnik;
            DodajRezervaciju = new RelayCommand<object>(rezervisi);
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter2); ;
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
