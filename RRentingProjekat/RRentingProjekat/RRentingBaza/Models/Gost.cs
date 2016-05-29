using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Gost : Korisnik
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GostId { get; set; }
        public int brojTiketa { get; set; }
        public DateTime datumDolaska { get; set; }
        public DateTime datumOdlaska { get; set; }
        
        public int ocjena { get; set; }
        public int brojSobe { get; set; }

    

       

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
       
        public Gost(string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email, int SID) : base(Ime, Prezime, Telefon, Adresa, Sifra, Email, 0)
        {
            brojTiketa = 0;
            brojSobe = 0;
            datumOdlaska = DateTime.Now;
            datumOdlaska = DateTime.Now;
            listaZahtjeva = new List<Zahtjev>();

            ocjena = 5;

        }

        public void dodijeliTiket(int t)
        {
            brojTiketa = t;
        }

        public void dodijeliOcjenu(int ocjena)
        {
            this.ocjena = ocjena;
        }

        public int dajOcjenu()
        {
            return ocjena;
        }
        public Gost() {}
    }
}
