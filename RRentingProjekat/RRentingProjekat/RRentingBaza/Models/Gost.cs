using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    public enum Ocjena {losa, dobra, super}
    class Gost: Osoba
    {
        public static int brojTiketa { get; set; }
        int brojSobe;
        DateTime datumDolaska, datumOdlaska;
        List<Zahtjev> listaZahtjeva;
        public Gost() { }
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
