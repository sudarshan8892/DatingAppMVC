using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
//Add-Migration  <NameMigration>,Update-Database
namespace WebAPIDatingAPP.DATA.migration
{
    public partial class UserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AppUsers",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AppUsers",
                newName: "Username");
        }
    }
}
