using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Sef:Osoba
    {
        //public int SigurnosniID { get; set; }
        public Sef() { }
        public Sef(int ID, string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email) : base(ID, Ime, Prezime, Telefon, Adresa, Sifra, Email)
        {
            BrojDanaDoNabavke = 0;
            uposlenici = new List<Osoblje>();
        }
        public int BrojDanaDoNabavke { get; set; }
        public List<Osoblje> uposlenici { get; set; }
        //JOS JEDAN KONSTRUKTOR
    }
}
