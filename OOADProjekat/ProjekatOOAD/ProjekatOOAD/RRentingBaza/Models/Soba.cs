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
        public int SobaId { get; set; } //primary key
        public string fourSquareId { get; set; } //za sinhronizaciju
        //status sobe
        public float CijenaSobe { get; set; } //cijena sobe
        public byte[] SlikaSobe { get; set; } //pocetna slika sobe
        public int BrojKreveta { get; set; } //broj kreveta u sobi
        public List<DateTime> RezervisaniDatumi { get; set; } //datumi kad je soba rezervisana
    }
}
