using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diamonds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Carat = table.Column<decimal>(nullable: false),
                    CertificateID = table.Column<string>(nullable: true),
                    CertificateLab = table.Column<int>(nullable: false),
                    CertificateURL = table.Column<string>(nullable: true),
                    Clarity = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    CrownAngle = table.Column<decimal>(nullable: false),
                    CrownHeight = table.Column<decimal>(nullable: false),
                    CrownHeightPercentage = table.Column<decimal>(nullable: false),
                    Culet = table.Column<int>(nullable: false),
                    CuletAngle = table.Column<decimal>(nullable: false),
                    CuletSize = table.Column<decimal>(nullable: false),
                    Cut = table.Column<int>(nullable: false),
                    DepthPercentage = table.Column<decimal>(nullable: false),
                    Fluorescence = table.Column<int>(nullable: false),
                    Girdle = table.Column<int>(nullable: false),
                    GirdleDiameter = table.Column<decimal>(nullable: false),
                    GirdleThickness = table.Column<decimal>(nullable: false),
                    GirdleToCuletDistance = table.Column<decimal>(nullable: false),
                    GirdleToTableDistance = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    ImagesURLValue = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: false),
                    LengthToWidthRatio = table.Column<decimal>(nullable: false),
                    LowerHalfLength = table.Column<decimal>(nullable: false),
                    LowerHalfLengthPercentage = table.Column<decimal>(nullable: false),
                    PavilionAngle = table.Column<decimal>(nullable: false),
                    PavilionDepth = table.Column<decimal>(nullable: false),
                    PavilionDepthPercentage = table.Column<decimal>(nullable: false),
                    Polish = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Shape = table.Column<int>(nullable: false),
                    ShippingDays = table.Column<int>(nullable: false),
                    StarLength = table.Column<decimal>(nullable: false),
                    StarLengthPercentage = table.Column<decimal>(nullable: false),
                    Symmetry = table.Column<int>(nullable: false),
                    TableWidth = table.Column<decimal>(nullable: false),
                    TableWidthPercentage = table.Column<decimal>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    VideosURLValue = table.Column<string>(nullable: true),
                    Width = table.Column<decimal>(nullable: false),
                    WirePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diamonds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diamonds");
        }
    }
}
