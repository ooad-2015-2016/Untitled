﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class Osoblje:Osoba
    {
        public int SigurnosniID { get; set; }
        List<Zahtjev> listaZahtjeva;
    }
}
