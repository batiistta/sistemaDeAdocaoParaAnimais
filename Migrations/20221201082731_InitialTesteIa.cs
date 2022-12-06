using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class InitialTesteIa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apego",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Energia",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Humor",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Apego",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Energia",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Humor",
                table: "animals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Apego",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Energia",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Humor",
                table: "usuarios",
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
        }
    }
}
