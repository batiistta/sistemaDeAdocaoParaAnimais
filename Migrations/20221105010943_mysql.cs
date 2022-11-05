using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class mysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals");

            migrationBuilder.DropTable(
                name: "especies");

            migrationBuilder.DropIndex(
                name: "IX_animals_EspeciesEspecieId",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Brincadeira",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "EspeciesEspecieId",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "FkEspecie",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Inteligencia",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "Latido",
                table: "animals");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "usuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Adestramento",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Apego",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.AddColumn<string>(
                name: "NomeSocial",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adestramento",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Apego",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Energia",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Humor",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "NomeSocial",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "usuarios",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Brincadeira",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EspeciesEspecieId",
                table: "animals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FkEspecie",
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

            migrationBuilder.AddColumn<int>(
                name: "Latido",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "especies",
                columns: table => new
                {
                    EspecieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especies", x => x.EspecieId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_animals_EspeciesEspecieId",
                table: "animals",
                column: "EspeciesEspecieId");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals",
                column: "EspeciesEspecieId",
                principalTable: "especies",
                principalColumn: "EspecieId");
        }
    }
}
