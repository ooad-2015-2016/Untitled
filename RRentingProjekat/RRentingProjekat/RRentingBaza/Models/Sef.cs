using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Sef:Osoba
    {
        public int SigurnosniID { get; set; }
        public Sef() { }
        public int BrojDanaDoNabavke { get; set; }
        List<Osoblje> uposlenici;

    }
}
