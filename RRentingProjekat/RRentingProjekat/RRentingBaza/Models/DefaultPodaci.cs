using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
    class DefaultPodaci
    {
        public static void Initialize(RRentingDbContext context)
        {
            if (!context.Sobe.Any())
            {
              
                context.Sobe.AddRange(
                    new Soba()
                    {
                        CijenaSobe = 0.0f,
                        BrojKreveta = 0,
                        Status = StatusSobe.Slobodna,
                        BrojSobe = 0,
                        RezervisaniDatumi = new List<DateTime>(),
                    });
                context.SaveChanges();

            }
            if (!context.Rezervacije.Any())
            {
                context.Rezervacije.AddRange(
                    new Rezervacija()
                    {
                        brojOdraslih = 0,
                        brojDjece = 0,
                        datumDolaska = DateTime.Now,
                        datumOdlaska = DateTime.Now,
                        parking = false,
                        ljubimac = false,
                        dodatniKrevet = false,
                        cijena = 0,
                        nacinPlacanja = NacinPlacanja.Gotovinsko,
                        placeno = false,
                    });
                context.SaveChanges();

            }

            if (!context.Zahtjevi.Any())
            {
                context.Zahtjevi.AddRange(
                    new Zahtjev()
                    {
                        nazivZahtjeva = "Spremanje sobe",
                        brojSobe = 1,
                        obavljenZahtjev = false,
                    }
                );
                context.SaveChanges();
            }

            if (!context.Korisnici.Any())
            {
                context.Korisnici.AddRange(
                    new Korisnik()
                    {

                        Ime = "",
                        Prezime = "",
                        Telefon = "",
                        Adresa = "",
                        Sifra = "",
                        Email = "",
                        SigurnosniID = 0,
                    }
            );
                context.SaveChanges();
            }


            }
    }
}
