using DAL.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*            migrationBuilder.Sql(
            @"CREATE PROCEDURE dbo.GetPersonByPESEL @PESEL decimal(11,0)
            AS BEGIN
            SELECT * FROM dbo.People
            WHERE PESEL = @PESEL
            END"
                            );*/
            migrationBuilder.Sql(Resources.StoredProcedure_UP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("DROP PROCEDURE dbo.GetPersonByPESEL");
            migrationBuilder.Sql(Resources.StoredProcedure_DOWN);
        }
    }
}
