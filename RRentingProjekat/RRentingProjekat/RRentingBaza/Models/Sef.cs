using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Sef:Korisnik
    {
        
        public Sef() { this.SigurnosniID = 123; }
        public Sef(string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email, int SID) : base(Ime, Prezime, Telefon, Adresa, Sifra, Email, 123)
        {
            BrojDanaDoNabavke = 0;
            uposlenici = new List<Osoblje>();

        }

        public void promijeniOsobljeId(Osoblje o, int novi ) { o.SigurnosniID = novi; }
        public void promijeniRecepcionerId(Recepcioner r, int novi) { r.SigurnosniID = novi; }

        public int BrojDanaDoNabavke { get; set; }
        public List<Osoblje> uposlenici { get; set; }
        //JOS JEDAN KONSTRUKTOR
    }
}
