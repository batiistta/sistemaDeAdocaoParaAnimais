using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class MudancaBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_usuarios_FkUsuarios",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_Enderecos_EnderecosEnderecoId",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_EnderecosEnderecoId",
                table: "Usuarios",
                newName: "IX_Usuarios_EnderecosEnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Usuarios_FkUsuarios",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_EnderecosEnderecoId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EnderecosEnderecoId",
                table: "usuarios",
                newName: "IX_usuarios_EnderecosEnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_usuarios_FkUsuarios",
                table: "Animals",
                column: "FkUsuarios",
                principalTable: "usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_Enderecos_EnderecosEnderecoId",
                table: "usuarios",
                column: "EnderecosEnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId");
        }
    }
}
