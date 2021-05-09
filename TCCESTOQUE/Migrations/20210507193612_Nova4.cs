using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class Nova4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Uf",
                table: "FornecedorEndereco",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2) CHARACTER SET utf8mb4",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Uf",
                table: "ClienteEndereco",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2) CHARACTER SET utf8mb4",
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "FornecedorEndereco",
                type: "varchar(2) CHARACTER SET utf8mb4",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "ClienteEndereco",
                type: "varchar(2) CHARACTER SET utf8mb4",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
