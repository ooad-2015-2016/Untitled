using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace RRentingProjekatMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Osoba",
                columns: table => new
                {
                    OsobaId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Telefon = table.Column(type: "TEXT", nullable: true),
                    fourSqaureId = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoba", x => x.OsobaId);
                });
            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    brojDjece = table.Column(type: "INTEGER", nullable: false),
                    brojOdraslih = table.Column(type: "INTEGER", nullable: false),
                    cijena = table.Column(type: "REAL", nullable: false),
                    datumDolaska = table.Column(type: "TEXT", nullable: false),
                    datumOdlaska = table.Column(type: "TEXT", nullable: false),
                    dodatniKrevet = table.Column(type: "INTEGER", nullable: false),
                    fourSquareId = table.Column(type: "TEXT", nullable: true),
                    ljubimac = table.Column(type: "INTEGER", nullable: false),
                    nacinPlacanja = table.Column(type: "INTEGER", nullable: false),
                    parking = table.Column(type: "INTEGER", nullable: false),
                    placeno = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                });
            migration.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    SobaId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    BrojKreveta = table.Column(type: "INTEGER", nullable: false),
                    BrojSobe = table.Column(type: "INTEGER", nullable: false),
                    CijenaSobe = table.Column(type: "REAL", nullable: false),
                    SlikaSobe = table.Column(type: "image", nullable: true),
                    Status = table.Column(type: "INTEGER", nullable: false),
                    fourSquareId = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.SobaId);
                });
            migration.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    ZahtjevId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    brojSobe = table.Column(type: "INTEGER", nullable: false),
                    fourSqaureId = table.Column(type: "TEXT", nullable: true),
                    nazivZahtjeva = table.Column(type: "TEXT", nullable: true),
                    obavljenZahtjev = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.ZahtjevId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Osoba");
            migration.DropTable("Rezervacija");
            migration.DropTable("Soba");
            migration.DropTable("Zahtjev");
        }
    }
}
