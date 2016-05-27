using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RRentingProjekat.RRentingBaza.Models
{
    public enum StatusSobe {Slobodna, Zauzeta, Rezervisana}

    class Soba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SobaId { get; set; } //primary key
        public string fourSquareId { get; set; } //za sinhronizaciju

        public int BrojSobe { get; set; }
        public StatusSobe Status { get; set; }
        public float CijenaSobe { get; set; } //cijena sobe
       // public byte[] SlikaSobe { get; set; } //pocetna slika sobe
        public int BrojKreveta { get; set; } //broj kreveta u sobi
        public List<DateTime> RezervisaniDatumi { get; set; } //datumi kad je soba rezervisana

        public Soba(){}

        public Soba(int id, int broj, StatusSobe status, float cijena, int brKrev)
        {
            RezervisaniDatumi = new List<DateTime>();
            SobaId = id;
            BrojSobe = broj;
            this.Status = status;
            CijenaSobe = cijena;
            BrojKreveta = brKrev;
        }

        //DODATI!
        void azurirajRezervisaneDatume()
        {
        }
    }
   
}
