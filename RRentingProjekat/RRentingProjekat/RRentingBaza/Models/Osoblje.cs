using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Osoblje:Osoba
    {
        public int SigurnosniID { get; set; }
        public List<Zahtjev> listaZahtjeva { get; set; }
    }
}
