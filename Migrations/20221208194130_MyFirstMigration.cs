using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fkCluster",
                table: "animals",
                newName: "FkCluster");

            migrationBuilder.AlterColumn<uint>(
                name: "FkCluster",
                table: "animals",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkCaracteristicaAnimal",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FkCaracteristicaAnimal",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "FkCluster",
                table: "animals",
                newName: "fkCluster");

            migrationBuilder.AlterColumn<int>(
                name: "fkCluster",
                table: "animals",
                type: "int",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned");
        }
    }
}
