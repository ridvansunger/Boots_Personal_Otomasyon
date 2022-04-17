using Microsoft.EntityFrameworkCore.Migrations;

namespace Boots_Personal_Otomasyon.DAL.Migrations
{
    public partial class TablesID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "UserAccounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonalID",
                table: "Personal",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Department",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAccounts",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Personal",
                newName: "PersonalID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "DepartmentID");
        }
    }
}
