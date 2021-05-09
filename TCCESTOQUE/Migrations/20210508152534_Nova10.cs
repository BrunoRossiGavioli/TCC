using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class Nova10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Fornecedor");

            migrationBuilder.AddColumn<bool>(
                name: "Desativado",
                table: "Fornecedor",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desativado",
                table: "Fornecedor");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Fornecedor",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
