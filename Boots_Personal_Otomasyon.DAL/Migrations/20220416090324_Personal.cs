using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boots_Personal_Otomasyon.DAL.Migrations
{
    public partial class Personal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameANdSurname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdentifierNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FaceBook = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Linkedlin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartMentId = table.Column<int>(type: "int", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalID);
                    table.ForeignKey(
                        name: "FK_Personal_Department_DepartMentId",
                        column: x => x.DepartMentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personal_DepartMentId",
                table: "Personal",
                column: "DepartMentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
