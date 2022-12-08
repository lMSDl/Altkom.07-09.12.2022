using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class UserHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password", "UserType" },
                values: new object[] { "SuperAdmin", "bmltZEE=", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password", "UserType" },
                values: new object[] { "User", "cmVzVQ==", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "SuperAdmin");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "User");
        }
    }
}
