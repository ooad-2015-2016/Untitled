using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRentingProjekat.RRentingBaza.Models
{
   
       class Korisnik
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int KorisnikId { get; set; }
            public string fourSqaureId { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Telefon { get; set; }
            public string Adresa { get; set; }
            public string Sifra { get; set; }
            public string Email { get; set; }

        public Korisnik() { }
        public Korisnik(int ID, string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email)
        {
            KorisnikId = ID;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Telefon = Telefon;
            this.Adresa = Adresa;
            this.Email = Email;
            this.Sifra = Sifra;

        }
        }
    }

