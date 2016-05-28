using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Osoblje : Korisnik
    {
        
        public List<Zahtjev> listaZahtjeva { get; set; }

        public Osoblje() { }
        public Osoblje(string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email, int SID) : base(Ime, Prezime, Telefon, Adresa, Sifra, Email, 02)
        {
            
            listaZahtjeva = new List<Zahtjev>();

        }
    }
}
