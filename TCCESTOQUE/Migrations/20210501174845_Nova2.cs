using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class Nova2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "FornecedorEndereco",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8) CHARACTER SET utf8mb4",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "ClienteEndereco",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8) CHARACTER SET utf8mb4",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11) CHARACTER SET utf8mb4",
                oldMaxLength: 11,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "FornecedorEndereco",
                type: "varchar(8) CHARACTER SET utf8mb4",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "ClienteEndereco",
                type: "varchar(8) CHARACTER SET utf8mb4",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "varchar(11) CHARACTER SET utf8mb4",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);
        }
    }
}
