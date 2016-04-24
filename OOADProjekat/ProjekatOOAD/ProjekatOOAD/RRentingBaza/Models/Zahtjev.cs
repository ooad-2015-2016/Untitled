using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RrentingProjekatBaza.ZahtjevBaza.Models
{
    class Zahtjev
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZahtjevId { get; set; }//primary key u bazi
        public string fourSqaureId { get; set; }//trebati ce za sihronizaciju kasnije
        public string nazivZahtjeva { get; set; }//naziv zahtjeva
        public int brojSobe { get; set; } //broj sobe koja ima neki zahtjev
        public bool obavljenZahtjev { get; set; } //oznacava da li je zahtjev obavljen 
    }
}
