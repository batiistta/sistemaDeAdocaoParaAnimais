using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class Cimatec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals");

            migrationBuilder.AlterColumn<int>(
                name: "EspeciesEspecieId",
                table: "animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaracteristicasId",
                table: "animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals",
                column: "CaracteristicasId",
                principalTable: "caracteristicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals",
                column: "EspeciesEspecieId",
                principalTable: "especies",
                principalColumn: "EspecieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals");

            migrationBuilder.AlterColumn<int>(
                name: "EspeciesEspecieId",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaracteristicasId",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals",
                column: "CaracteristicasId",
                principalTable: "caracteristicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals",
                column: "EspeciesEspecieId",
                principalTable: "especies",
                principalColumn: "EspecieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
