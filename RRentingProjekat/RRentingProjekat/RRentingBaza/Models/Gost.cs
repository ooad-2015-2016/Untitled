using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    public enum Ocjena {losa, dobra, super}
    class Gost : Osoba
    {
        public static int brojTiketa { get; set; }
        public int brojSobe { get; set; }
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

    }
}
