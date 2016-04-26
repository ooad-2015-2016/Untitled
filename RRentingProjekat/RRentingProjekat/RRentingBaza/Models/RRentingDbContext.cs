using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;


namespace RRentingProjekat.RRentingBaza.Models
{
    class RRentingDbContext : DbContext
    {
        public DbSet<Soba> Sobe { get; set; } //sve sobe
        public DbSet<Rezervacija> Rezervacije { get; set; } //sve rezervacije
        public DbSet<Osoba> Osobe { get; set; } //sve osobe
        public DbSet<Zahtjev> Zahtjevi { get; set; } //svi zahtjevi

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Ooadbaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);

            }
            catch (InvalidOperationException) { }

            //Sqlite baza
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //jedno od polja je image da se zna šta je zapravo predstavlja byte[]; SLIKA SOBE
            modelBuilder.Entity<Soba>().Property(p => p.SlikaSobe).HasColumnType("image");
        }
    }
}

