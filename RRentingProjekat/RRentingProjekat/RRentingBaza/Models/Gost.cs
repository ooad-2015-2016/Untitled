using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    public enum Ocjena {losa, dobra, super}
    class Gost : Korisnik
    {
        public static int brojTiketa { get; set; }
        public Soba soba { get; set; }
        public DateTime datumDolaska { get; set; }
        public DateTime datumOdlaska { get; set; }
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

        public Gost()
        {
        }
    }
}
