using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Recepcioner : Korisnik
    {
        public Recepcioner() { }
        public Recepcioner(string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email, int SID) : base(Ime, Prezime, Telefon, Adresa, Sifra, Email, 03)
        {
      

        }

        public float ObracunCijene (int tiket)
        {
            return tiket*20;
        }

        public void promijeniStatusSobe(Soba soba, StatusSobe s) { soba.Status = s; }
 
    }
}
