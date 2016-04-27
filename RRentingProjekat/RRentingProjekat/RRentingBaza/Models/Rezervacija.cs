using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;


namespace RRentingProjekat.RRentingBaza.Models
{
    public enum NacinPlacanja {Gotovinsko, Karticom}
    class Rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RezervacijaId { get; set; } //Primarni kljuc
        public string fourSquareId { get; set; } //za sinhronizaciju
        public NacinPlacanja nacinPlacanja {get;set;}
        public Boolean placeno { get; set; }
        public int brojOdraslih { get; set; }
        public int brojDjece { get; set; }
        public Boolean ljubimac { get; set; }
        public Boolean parking { get; set; }
        public Boolean dodatniKrevet { get; set; }
        public float cijena { get; set; }
        public DateTime datumOdlaska { get; set; }
        public DateTime datumDolaska { get; set; }

    }
}
