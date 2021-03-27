using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(maxLength: 70, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Logado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
