using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class AdicionandoInativoParaTodasAsEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Vendedor");

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "Vendedor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "Fornecedor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "Cliente",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "Cliente");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Vendedor",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
