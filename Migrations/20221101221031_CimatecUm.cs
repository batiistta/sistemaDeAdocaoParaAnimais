using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class CimatecUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals");

            migrationBuilder.DropTable(
                name: "caracteristicas");

            migrationBuilder.DropIndex(
                name: "IX_animals_CaracteristicasId",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "CaracteristicasId",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "FkCaracteristica",
                table: "animals",
                newName: "Latido");

            migrationBuilder.AddColumn<int>(
                name: "Adestramento",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Apego",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Brincadeira",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Castrado",
                table: "animals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Energia",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Humor",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inteligencia",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Vacinado",
                table: "animals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vermifugado",
                table: "animals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adestramento",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Apego",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Brincadeira",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Castrado",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Energia",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Humor",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Inteligencia",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Vacinado",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Vermifugado",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "Latido",
                table: "animals",
                newName: "FkCaracteristica");

            migrationBuilder.AddColumn<int>(
                name: "CaracteristicasId",
                table: "animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "caracteristicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Adestramento = table.Column<int>(type: "int", nullable: false),
                    Apego = table.Column<int>(type: "int", nullable: false),
                    Brincadeira = table.Column<int>(type: "int", nullable: false),
                    Castrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Energia = table.Column<int>(type: "int", nullable: false),
                    Humor = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Latido = table.Column<int>(type: "int", nullable: false),
                    Vacinado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Vermifugado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_animals_CaracteristicasId",
                table: "animals",
                column: "CaracteristicasId");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals",
                column: "CaracteristicasId",
                principalTable: "caracteristicas",
                principalColumn: "Id");
        }
    }
}
