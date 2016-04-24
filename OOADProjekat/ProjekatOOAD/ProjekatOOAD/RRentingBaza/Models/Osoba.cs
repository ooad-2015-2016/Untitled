using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatOOAD.RRentingBaza.Models
{
    class Osoba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OsobaId { get; set; }
        public string fourSqaureId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Sifra { get; set; }
        public int Rating { get; internal set; }
    }
}
