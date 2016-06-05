using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace RRentingProjekat.RRentingBaza.Models
{
    [DataContract]
    class Korisnik
        {
        [DataMember]
        public string fourSqaureId { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public string Adresa { get; set; }
        [DataMember]
        public string Sifra { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public int SigurnosniID { get; set; }
            

        public Korisnik() { }
        public Korisnik(string Ime, string Prezime, string Telefon, string Adresa, string Sifra, string Email, int SID)
        {
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Telefon = Telefon;
            this.Adresa = Adresa;
            this.Email = Email;
            this.Sifra = Sifra;
            SigurnosniID = SID;

        }

      }
 }

