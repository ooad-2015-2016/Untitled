using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.RRentingBaza.Models
{
    class SobaDefaultPodaci
    {
        public static void Initialize(SobaDbContext context)
        {
            if (!context.Sobe.Any())
            {
                context.Sobe.AddRange(
                    new Soba()
                    {
                        CijenaSobe = 0.0f,
                        BrojKreveta = 0,
                    });
                context.SaveChanges();

            }
        }
    }
}
