using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIDatingAPP.DATA.migration
{
    public partial class RenameUsernameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsreName",
                table: "AppUsers",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "AppUsers",
                newName: "UsreName");
        }
    }
}
