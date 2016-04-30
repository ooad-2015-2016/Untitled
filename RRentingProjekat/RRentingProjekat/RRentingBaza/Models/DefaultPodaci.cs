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
        }
    }
}
