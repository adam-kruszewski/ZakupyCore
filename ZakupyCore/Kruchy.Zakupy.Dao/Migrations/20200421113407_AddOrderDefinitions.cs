using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kruchy.Zakupy.Dao.Migrations
{
    public partial class AddOrderDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefinicjeZamowienia",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(nullable: true),
                    DataKoncaZamawiania = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinicjeZamowienia", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefinicjeZamowienia");
        }
    }
}
