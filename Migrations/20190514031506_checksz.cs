using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class checksz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCheckins",
                columns: table => new
                {
                    checkinId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    checkinLicensePlate = table.Column<string>(nullable: true),
                    checkinTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCheckins", x => x.checkinId);
                });

            migrationBuilder.CreateTable(
                name: "CarCheckOuts",
                columns: table => new
                {
                    checkoutId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    checkoutLicensePlate = table.Column<string>(nullable: true),
                    checkoutTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCheckOuts", x => x.checkoutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCheckins");

            migrationBuilder.DropTable(
                name: "CarCheckOuts");
        }
    }
}
