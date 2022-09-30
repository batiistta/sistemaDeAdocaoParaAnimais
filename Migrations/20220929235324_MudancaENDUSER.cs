using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaDeAdocaoParaAnimais.Migrations
{
    public partial class MudancaENDUSER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_enderecos_EnderecosEnderecoId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_EnderecosEnderecoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecosEnderecoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "FkEndereco",
                table: "usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "usuarios");

            migrationBuilder.AddColumn<int>(
                name: "EnderecosEnderecoId",
                table: "usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FkEndereco",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rua = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.EnderecoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_EnderecosEnderecoId",
                table: "usuarios",
                column: "EnderecosEnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_enderecos_EnderecosEnderecoId",
                table: "usuarios",
                column: "EnderecosEnderecoId",
                principalTable: "enderecos",
                principalColumn: "EnderecoId");
        }
    }
}
