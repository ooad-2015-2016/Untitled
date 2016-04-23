using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatOOADMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    SobaId = table.Column(type: "INTEGER", nullable: false),
                    //.Annotation("Sqlite:Autoincrement", true),
                    BrojKreveta = table.Column(type: "INTEGER", nullable: false),
                    CijenaSobe = table.Column(type: "REAL", nullable: false),
                    SlikaSobe = table.Column(type: "image", nullable: true),
                    fourSquareId = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.SobaId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Soba");
        }
    }
}
