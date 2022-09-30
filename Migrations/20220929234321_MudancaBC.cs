using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class MudancaBC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Caracteristicas_CaracteristicasId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Especies_EspeciesEspecieId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Usuarios_FkUsuarios",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecosEnderecoId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Especies",
                table: "Especies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caracteristicas",
                table: "Caracteristicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Especies",
                newName: "especies");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "enderecos");

            migrationBuilder.RenameTable(
                name: "Caracteristicas",
                newName: "caracteristicas");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "animals");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EnderecosEnderecoId",
                table: "usuarios",
                newName: "IX_usuarios_EnderecosEnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_FkUsuarios",
                table: "animals",
                newName: "IX_animals_FkUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_EspeciesEspecieId",
                table: "animals",
                newName: "IX_animals_EspeciesEspecieId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_CaracteristicasId",
                table: "animals",
                newName: "IX_animals_CaracteristicasId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_especies",
                table: "especies",
                column: "EspecieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos",
                column: "EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_caracteristicas",
                table: "caracteristicas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_animals",
                table: "animals",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_animals_usuarios_FkUsuarios",
                table: "animals",
                column: "FkUsuarios",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_enderecos_EnderecosEnderecoId",
                table: "usuarios",
                column: "EnderecosEnderecoId",
                principalTable: "enderecos",
                principalColumn: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animals_caracteristicas_CaracteristicasId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_especies_EspeciesEspecieId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_usuarios_FkUsuarios",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_enderecos_EnderecosEnderecoId",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_especies",
                table: "especies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enderecos",
                table: "enderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_caracteristicas",
                table: "caracteristicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_animals",
                table: "animals");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "especies",
                newName: "Especies");

            migrationBuilder.RenameTable(
                name: "enderecos",
                newName: "Enderecos");

            migrationBuilder.RenameTable(
                name: "caracteristicas",
                newName: "Caracteristicas");

            migrationBuilder.RenameTable(
                name: "animals",
                newName: "Animals");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_EnderecosEnderecoId",
                table: "Usuarios",
                newName: "IX_Usuarios_EnderecosEnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_animals_FkUsuarios",
                table: "Animals",
                newName: "IX_Animals_FkUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_animals_EspeciesEspecieId",
                table: "Animals",
                newName: "IX_Animals_EspeciesEspecieId");

            migrationBuilder.RenameIndex(
                name: "IX_animals_CaracteristicasId",
                table: "Animals",
                newName: "IX_Animals_CaracteristicasId");

            migrationBuilder.AlterColumn<int>(
                name: "EspeciesEspecieId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaracteristicasId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Especies",
                table: "Especies",
                column: "EspecieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caracteristicas",
                table: "Caracteristicas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Caracteristicas_CaracteristicasId",
                table: "Animals",
                column: "CaracteristicasId",
                principalTable: "Caracteristicas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Especies_EspeciesEspecieId",
                table: "Animals",
                column: "EspeciesEspecieId",
                principalTable: "Especies",
                principalColumn: "EspecieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Usuarios_FkUsuarios",
                table: "Animals",
                column: "FkUsuarios",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecosEnderecoId",
                table: "Usuarios",
                column: "EnderecosEnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId");
        }
    }
}
