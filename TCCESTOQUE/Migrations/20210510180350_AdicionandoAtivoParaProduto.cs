using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class AdicionandoAtivoParaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoProduto",
                table: "VendaItens",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoProduto",
                table: "VendaItens",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<bool>(
                name: "Inativo",
                table: "Produto",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inativo",
                table: "Produto");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoProduto",
                table: "VendaItens",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoProduto",
                table: "VendaItens",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");
        }
    }
}
