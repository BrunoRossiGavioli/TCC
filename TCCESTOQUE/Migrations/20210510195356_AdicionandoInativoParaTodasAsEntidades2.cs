using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class AdicionandoInativoParaTodasAsEntidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desativado",
                table: "Fornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Desativado",
                table: "Fornecedor",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
