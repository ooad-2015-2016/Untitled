using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace ProjekatOOAD.RRentingBaza.Models
{
    class OsobaDbContext : DbContext
    {
              public DbSet<Osoba> Osobe { get; set; }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Oooad.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path,
               databaseFilePath);
            }
            catch (InvalidOperationException) { }
         
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
        }
    }
}
