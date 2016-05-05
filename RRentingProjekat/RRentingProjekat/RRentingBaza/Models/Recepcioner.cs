using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Recepcioner:Osoba
    {
        public int SigurnosniID { get; set; }

        public float ObracunCijene (int tiket)
        {
            return tiket*20;
        }
        public bool StatusSobe { get; set; }
    }
}
