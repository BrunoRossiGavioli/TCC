using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class Novo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Fornecedor",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50) CHARACTER SET utf8mb4",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedor",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14) CHARACTER SET utf8mb4",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Fornecedor",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Fornecedor");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Vendedor",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeFantasia",
                table: "Fornecedor",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Fornecedor",
                type: "varchar(14) CHARACTER SET utf8mb4",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Fornecedor",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Fornecedor",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
