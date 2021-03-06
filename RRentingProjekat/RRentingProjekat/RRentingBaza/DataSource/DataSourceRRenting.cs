﻿using System;
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
            new Sef("AdminIme", "AdminPrezime", "033/555-555", "AdresaHotela", "AdminPass", "admin@gmail.com", 01),
            new Osoblje("Ana", "Simone", "033/111-555", "California Beach 12" , "APass", "ana@gmail.com", 02),
            new Osoblje("Michael", "Winehouse", "033/111-555", "LA Street 2", "MPass", "michael@gmail.com", 02),
            new Recepcioner("RecepIme", "RecepPrezime", "033/333-555", "AdresaRecep", "RecepPass", "recep@gmail.com", 03)

        };

        internal static List<Korisnik> DajSveKorisnike()
        {
            return korisnici;
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

       

        internal static Gost ProvjeraGosta(string korisnickiMail, string sifra)
        {
            Gost kor = new Gost();
            foreach (var k in korisnici)
            {
                if (k.Email == korisnickiMail && k.Sifra == sifra) { kor = k as Gost; }
            }
            return kor;

        }

       


        #endregion

        #region Sobe
        private static List<Soba> sobe = new List<Soba>()
        {
            new Soba(1, 1, StatusSobe.Slobodna, 50, 3),
             new Soba(2, 2, StatusSobe.Rezervisana, 100, 4),
              new Soba(3, 3, StatusSobe.Slobodna, 30, 2),
               new Soba(4, 4, StatusSobe.Zauzeta, 150, 5),
                 new Soba(5, 5, StatusSobe.Slobodna, 50, 3),
                new Soba(6, 6, StatusSobe.Zauzeta, 150, 5),
                 new Soba(7, 4, StatusSobe.Rezervisana, 50,3),
                 new Soba(8, 3, StatusSobe.Slobodna, 350, 5),
                 new Soba(9, 5, StatusSobe.Zauzeta, 400, 4),
                 new Soba(10, 6, StatusSobe.Slobodna, 450, 5)



        };

        internal static List<Soba> DajSveSobe()
        {
            return sobe;
        }

        internal static Soba DajSobePoId(int sobaId)
        {
            return sobe.Where(k => k.SobaId.Equals(sobaId)).FirstOrDefault();
        }

        internal static Soba dajSlobodnuSobu(Rezervacija rez)
        {
            Soba soba = new Soba();
            foreach (var s in sobe)
            {
                if (s.Status == StatusSobe.Slobodna && (rez.brojDjece+rez.brojOdraslih == s.BrojKreveta)) { 
                    soba = s;
                    break;                    
                }
            }
            return soba;

        }
        #endregion
    }


}
