using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class OneToOneOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
