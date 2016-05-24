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
        #region Korisnik - kreiranje testnih korisnika
        private static List<Korisnik> korisnici = new List<Korisnik>()
        {
            new Sef(1, "AdminIme", "AdminPrezime", "033/555-555", "AdresaHotela", "AdminPass", "admin@gmail.com", 01),
            new Gost(2, "GostIme1", "GostPrezime1", "033/222-555", "AdresaGost1", "Gost1Pass", "gost1@gmail.com", 0),
            new Osoblje(3, "Osoblje1Ime", "Osoblje1Prezime", "033/111-555", "AdresaOsoblje1", "Osoblje1Pass", "osoblje1@gmail.com", 01),
            new Recepcioner(4, "RecepIme", "RecepPrezime", "033/333-555", "AdresaRecep", "RecepPass", "recep@gmail.com", 03)

        };

        internal static IList<Korisnik> DajSveKorisnike()
        {
            return korisnici;
        }

        internal static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }

        internal static Korisnik ProvjeraUposlenika(string korisnickiMail, string sifra, int ID)
        {
            

            Korisnik kor = new Korisnik();
            foreach (var k in korisnici)
            {
                if (k.Email == korisnickiMail && k.Sifra == sifra && k.SigurnosniID == ID) kor = k;
            }
            return kor;

        }


        internal static Korisnik ProvjeraGosta(string korisnickiMail, string sifra)
        {
            Korisnik kor = new Korisnik();
            foreach (var k in korisnici)
            {
                if (k.Email == korisnickiMail && k.Sifra == sifra) kor = k;
            }
            return kor;

        }

        #endregion

    }

}
