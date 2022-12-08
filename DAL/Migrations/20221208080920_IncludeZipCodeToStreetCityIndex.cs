using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class IncludeZipCodeToStreetCityIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_Street_City",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Street_City",
                table: "Addresses",
                columns: new[] { "Street", "City" },
                unique: true)
                .Annotation("SqlServer:Include", new[] { "ZipCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_Street_City",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_Street_City",
                table: "Addresses",
                columns: new[] { "Street", "City" },
                unique: true);
        }
    }
}
