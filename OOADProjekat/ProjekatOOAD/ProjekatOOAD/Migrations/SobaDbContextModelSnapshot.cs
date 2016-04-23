using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatOOAD.RRentingBaza.Models;

namespace ProjekatOOADMigrations
{
    [ContextType(typeof(SobaDbContext))]
    partial class SobaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatOOAD.RRentingBaza.Models.Soba", b =>
                {
                    b.Property<int>("SobaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojKreveta");

                    b.Property<float>("CijenaSobe");

                    b.Property<byte[]>("SlikaSobe")
                        .Annotation("Relational:ColumnType", "image");

                    b.Property<string>("fourSquareId");

                    b.Key("SobaId");
                });
        }
    }
}
