using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using RRentingProjekat.RRentingBaza.Models;

namespace RRentingProjekatMigrations
{
    [ContextType(typeof(RRentingDbContext))]
    partial class RRentingDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("RRentingProjekat.RRentingBaza.Models.Gost", b =>
                {
                    b.Property<int>("GostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("RfidKartica");

                    b.Property<string>("Sifra");

                    b.Property<int>("SigurnosniID");

                    b.Property<string>("Telefon");

                    b.Property<int>("brojSobe");

                    b.Property<int>("brojTiketa");

                    b.Property<DateTime>("datumDolaska");

                    b.Property<DateTime>("datumOdlaska");

                    b.Property<string>("fourSqaureId");

                    b.Property<int>("ocjena");

                    b.Key("GostId");
                });

            builder.Entity("RRentingProjekat.RRentingBaza.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("brojDjece");

                    b.Property<int>("brojOdraslih");

                    b.Property<float>("cijena");

                    b.Property<DateTime>("datumDolaska");

                    b.Property<DateTime>("datumOdlaska");

                    b.Property<bool>("dodatniKrevet");

                    b.Property<string>("fourSquareId");

                    b.Property<bool>("ljubimac");

                    b.Property<int>("nacinPlacanja");

                    b.Property<bool>("parking");

                    b.Property<bool>("placeno");

                    b.Key("RezervacijaId");
                });

            builder.Entity("RRentingProjekat.RRentingBaza.Models.Soba", b =>
                {
                    b.Property<int>("SobaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojKreveta");

                    b.Property<int>("BrojSobe");

                    b.Property<float>("CijenaSobe");

                    b.Property<int>("Status");

                    b.Property<string>("fourSquareId");

                    b.Key("SobaId");
                });

            builder.Entity("RRentingProjekat.RRentingBaza.Models.Zahtjev", b =>
                {
                    b.Property<int>("ZahtjevId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GostGostId");

                    b.Property<int>("brojSobe");

                    b.Property<string>("fourSqaureId");

                    b.Property<string>("nazivZahtjeva");

                    b.Property<bool>("obavljenZahtjev");

                    b.Key("ZahtjevId");
                });

            builder.Entity("RRentingProjekat.RRentingBaza.Models.Zahtjev", b =>
                {
                    b.Reference("RRentingProjekat.RRentingBaza.Models.Gost")
                        .InverseCollection()
                        .ForeignKey("GostGostId");
                });
        }
    }
}
