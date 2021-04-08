using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCCESTOQUE.Migrations
{
    public partial class Novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    ForncedorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.ForncedorId);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(maxLength: 70, nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Logado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorEndereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 80, nullable: false),
                    Complemento = table.Column<string>(maxLength: 80, nullable: true),
                    Numero = table.Column<int>(maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(maxLength: 80, nullable: false),
                    Localidade = table.Column<string>(maxLength: 80, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorEndereco_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "ForncedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true),
                    Custo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "ForncedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorEndereco_FornecedorId",
                table: "FornecedorEndereco",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FornecedorEndereco");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
