using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class OneToOneOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_RegistrationId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_RegistrationId",
                table: "Vehicle",
                column: "RegistrationId",
                unique: true,
                filter: "[RegistrationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_RegistrationId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_RegistrationId",
                table: "Vehicle",
                column: "RegistrationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Registration_RegistrationId",
                table: "Vehicle",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
