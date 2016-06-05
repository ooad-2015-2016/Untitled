using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPRRenting2
{
    public class _Korisnik
    {

        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Sifra { get; set; }
        public string Email { get; set; }

        public int SigurnosniID { get; set; }
    }

    public class KorisnikDbContext : DbContext
    {
      public DbSet<_Korisnik> Korisnicni { get; set; }
    }
}