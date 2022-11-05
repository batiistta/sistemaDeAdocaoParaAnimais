using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class Funcesasas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeSocial",
                table: "usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "NomeSocial",
                keyValue: null,
                column: "NomeSocial",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NomeSocial",
                table: "usuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
