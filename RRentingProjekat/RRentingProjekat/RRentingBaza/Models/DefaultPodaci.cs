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
               // DateTime nulti = new DateTime(0000, 00, 00);
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
                // DateTime nulti = new DateTime(0000, 00, 00);
                context.Rezervacije.AddRange(
                    new Rezervacija()
                    {
                        brojOdraslih = 0,
                        brojDjece =0,
                        datumDolaska = DateTime.Now,
                        datumOdlaska = DateTime.Now,
                        parking = false,
                        ljubimac = false,
                        dodatniKrevet = false,
                        cijena = 500,
                        nacinPlacanja = NacinPlacanja.Gotovinsko,
                    });
                context.SaveChanges();

            }
        }
    }
}
