using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class OI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adestramento",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Adestramento",
                table: "animals");

            migrationBuilder.AddColumn<float>(
                name: "Adestramento",
                table: "caracteristicaUsuarios",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Brincalhao",
                table: "caracteristicaUsuarios",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Adestramento",
                table: "caracteristicaAnimals",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Brincalhao",
                table: "caracteristicaAnimals",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adestramento",
                table: "caracteristicaUsuarios");

            migrationBuilder.DropColumn(
                name: "Brincalhao",
                table: "caracteristicaUsuarios");

            migrationBuilder.DropColumn(
                name: "Adestramento",
                table: "caracteristicaAnimals");

            migrationBuilder.DropColumn(
                name: "Brincalhao",
                table: "caracteristicaAnimals");

            migrationBuilder.AddColumn<int>(
                name: "Adestramento",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Adestramento",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
