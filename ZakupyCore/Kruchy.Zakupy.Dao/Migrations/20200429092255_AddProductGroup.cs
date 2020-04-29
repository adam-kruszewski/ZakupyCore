using Microsoft.EntityFrameworkCore.Migrations;

namespace Kruchy.Zakupy.Dao.Migrations
{
    public partial class AddProductGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupyProduktow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(nullable: true),
                    Limit = table.Column<int>(nullable: true),
                    DefinicjaZamowieniaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupyProduktow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupyProduktow_DefinicjeZamowienia_DefinicjaZamowieniaId",
                        column: x => x.DefinicjaZamowieniaId,
                        principalTable: "DefinicjeZamowienia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupyProduktow_DefinicjaZamowieniaId",
                table: "GrupyProduktow",
                column: "DefinicjaZamowieniaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupyProduktow");
        }
    }
}
