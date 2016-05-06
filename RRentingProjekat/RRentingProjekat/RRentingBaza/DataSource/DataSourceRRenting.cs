using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRentingProjekat.RRentingBaza.Models;

namespace RRentingProjekat.RRentingBaza.DataSource
{
    public class DataSourceRRenting
    {
        #region Korisnik - kreiranje početnog korisnika
        private static List<Osoba> korisnici = new List<Osoba>()
        {
            new Sef(1, "AdminIme", "AdminPrezime", "033/555-555", "AdresaHotela", "AdminPass", "admin@gmailcom")


        };
        #endregion

    }

}
