using Microsoft.EntityFrameworkCore.Migrations;

namespace Kruchy.Zakupy.Dao.Migrations
{
    public partial class ChangeProductTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Produkt");

            migrationBuilder.CreateTable(
                 name: "Produkty",
                 columns: table => new
                 {
                     Id = table.Column<int>(nullable: false)
                         .Annotation("Sqlite:Autoincrement", true),
                     Nazwa = table.Column<string>(nullable: true),
                     Cena = table.Column<decimal>(nullable: false),
                     GrupaProduktowId = table.Column<int>(nullable: false),
                     NumerWierszaWExcelu = table.Column<int>(nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Produkty", x => x.Id);
                     table.ForeignKey(
                         name: "FK_Produkty_GrupyProduktow_GrupaProduktowId",
                         column: x => x.GrupaProduktowId,
                         principalTable: "GrupyProduktow",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                 });

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_GrupaProduktowId",
                table: "Produkty",
                column: "GrupaProduktowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}