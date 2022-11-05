using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class Funcesasasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagensPet",
                table: "animals",
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
                table: "animals",
                keyColumn: "ImagensPet",
                keyValue: null,
                column: "ImagensPet",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImagensPet",
                table: "animals",
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
