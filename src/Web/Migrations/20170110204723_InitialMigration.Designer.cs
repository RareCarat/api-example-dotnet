using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using API.RareCarat.Example.Model;

namespace Web.Migrations
{
    [DbContext(typeof(RetailerDBContext))]
    [Migration("20170110204723_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.RareCarat.Example.Model.Diamond", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Carat");

                    b.Property<string>("CertificateID");

                    b.Property<int>("CertificateLab");

                    b.Property<string>("CertificateURL");

                    b.Property<int>("Clarity");

                    b.Property<int>("Color");

                    b.Property<decimal>("CrownAngle");

                    b.Property<decimal>("CrownHeight");

                    b.Property<decimal>("CrownHeightPercentage");

                    b.Property<int>("Culet");

                    b.Property<decimal>("CuletAngle");

                    b.Property<decimal>("CuletSize");

                    b.Property<int>("Cut");

                    b.Property<decimal>("DepthPercentage");

                    b.Property<int>("Fluorescence");

                    b.Property<int>("Girdle");

                    b.Property<decimal>("GirdleDiameter");

                    b.Property<decimal>("GirdleThickness");

                    b.Property<decimal>("GirdleToCuletDistance");

                    b.Property<decimal>("GirdleToTableDistance");

                    b.Property<decimal>("Height");

                    b.Property<string>("ImagesURLValue");

                    b.Property<decimal>("Length");

                    b.Property<decimal>("LengthToWidthRatio");

                    b.Property<decimal>("LowerHalfLength");

                    b.Property<decimal>("LowerHalfLengthPercentage");

                    b.Property<decimal>("PavilionAngle");

                    b.Property<decimal>("PavilionDepth");

                    b.Property<decimal>("PavilionDepthPercentage");

                    b.Property<int>("Polish");

                    b.Property<decimal>("Price");

                    b.Property<int>("Shape");

                    b.Property<int>("ShippingDays");

                    b.Property<decimal>("StarLength");

                    b.Property<decimal>("StarLengthPercentage");

                    b.Property<int>("Symmetry");

                    b.Property<decimal>("TableWidth");

                    b.Property<decimal>("TableWidthPercentage");

                    b.Property<string>("URL")
                        .IsRequired();

                    b.Property<string>("VideosURLValue");

                    b.Property<decimal>("Width");

                    b.Property<decimal>("WirePrice");

                    b.HasKey("Id");

                    b.ToTable("Diamonds");
                });
        }
    }
}
