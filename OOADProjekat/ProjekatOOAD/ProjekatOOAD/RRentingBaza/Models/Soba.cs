using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.RRentingBaza.Models
{
    class Soba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int brojSobe { get; set; } //primary key
        public string fourSquareId { get; set; } //za sinhronizaciju
        //status sobe
        public float cijenaSobe { get; set; }
    }
}
