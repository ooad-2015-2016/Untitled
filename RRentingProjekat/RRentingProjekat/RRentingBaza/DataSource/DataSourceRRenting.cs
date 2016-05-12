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
        private static List<Korisnik> korisnici = new List<Korisnik>()
        {
            new Sef(1, "AdminIme", "AdminPrezime", "033/555-555", "AdresaHotela", "AdminPass", "admin@gmail.com", 01)


        };

        internal static IList<Korisnik> DajSveKorisnike()
        {
            return korisnici;
        }

        internal static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }

        internal static Korisnik ProvjeraKorisnika(string korisnickiMail, string sifra, int ID)
        {
            /* Korisnik sef = new Sef();
             Korisnik osoblje = new Osoblje();
             Korisnik rec = new Recepcioner();
             */

            Korisnik kor = new Korisnik();
            foreach (var k in korisnici)
            {
                if (k.Email == korisnickiMail && k.Sifra == sifra && k.SigurnosniID == ID) kor = k;
            }
            return kor;

        }
        #endregion

    }

}
