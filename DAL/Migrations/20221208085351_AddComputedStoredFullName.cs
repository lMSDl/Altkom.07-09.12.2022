using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddComputedStoredFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ' ' + [LastName]",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[Name] + ' ' + [LastName]",
                oldStored: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[Name] + ' ' + [LastName]");
        }
    }
}
