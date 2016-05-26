using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    public enum Ocjena {losa, dobra, super}
    class Gost : Korisnik, INotifyPropertyChanged
    {
        public int brojTiketa { get; set; }
        public Soba soba { get; set; }
        public DateTime datumDolaska { get; set; }
        public DateTime datumOdlaska { get; set; }
        private string rfidKartica;//Rfid string procitan sa kartice
        //Regex da ocisti simbole koji bi mogli prouzrokovati probleme poput enter znaka i
        //slicno
       //mora prozvati property changed jer je na njega vezano polje koje se treba promijeniti kad se
      // povuce kartica, bez ovog, textbox prazan
 public string RfidKartica { get { return rfidKartica; }
            set
            {
                rfidKartica = Regex.Replace(value,
"[^0-9a-zA-Z]+", ""); OnNotifyPropertyChanged("RfidKartica");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public List<Zahtjev> listaZahtjeva { get; set; }
        //public Gost() { }
        /*public void DodajZahtjev (Zahtjev zahtjev)
        {
            foreach(Zahtjev zah in listaZahtjeva)
            {
                listaZahtjeva.Add(zah);
            }
        }
        */
        //public Ocjena OcijeniUsluge { get; set; }
        public Gost(int ID, string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email, int SID) : base(ID, Ime, Prezime, Telefon, Adresa, Sifra, Email, 0)
        {
            brojTiketa = 0;
            soba = null;
            datumOdlaska = DateTime.Now;
            datumOdlaska = DateTime.Now;
            listaZahtjeva = new List<Zahtjev>();

        }

        public void dodijeliTiket(int t)
        {
            brojTiketa = t;
        }

        public Gost()
        {
        }
    }
}
