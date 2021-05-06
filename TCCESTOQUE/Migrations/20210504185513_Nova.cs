﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TCCESTOQUE.Migrations
{
    public partial class Nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    VendedorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Senha = table.Column<string>(maxLength: 70, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(maxLength: 14, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Logado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.VendedorId);
                });

            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    CarrinhoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.CarrinhoId);
                    table.ForeignKey(
                        name: "FK_Carrinho_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: true),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    VendedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(maxLength: 50, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 18, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(maxLength: 14, nullable: true),
                    VendedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.FornecedorId);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEndereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 80, nullable: false),
                    Complemento = table.Column<string>(maxLength: 80, nullable: true),
                    Numero = table.Column<int>(maxLength: 6, nullable: false),
                    Bairro = table.Column<string>(maxLength: 80, nullable: false),
                    Localidade = table.Column<string>(maxLength: 80, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEndereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_ClienteEndereco_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    VendaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorEndereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cep = table.Column<string>(maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 80, nullable: false),
                    Complemento = table.Column<string>(maxLength: 80, nullable: true),
                    Numero = table.Column<int>(maxLength: 6, nullable: false),
                    Bairro = table.Column<string>(maxLength: 80, nullable: false),
                    Localidade = table.Column<string>(maxLength: 80, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorEndereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_FornecedorEndereco_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true),
                    Custo = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaItens",
                columns: table => new
                {
                    VendaItensId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VendaId = table.Column<int>(nullable: true),
                    CarrinhoId = table.Column<int>(nullable: true),
                    VendedorId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaItens", x => x.VendaItensId);
                    table.ForeignKey(
                        name: "FK_VendaItens_Carrinho_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinho",
                        principalColumn: "CarrinhoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendaItens_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaItens_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VendaItens_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "VendedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_VendedorId",
                table: "Carrinho",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_VendedorId",
                table: "Cliente",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEndereco_ClienteId",
                table: "ClienteEndereco",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_VendedorId",
                table: "Fornecedor",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorEndereco_FornecedorId",
                table: "FornecedorEndereco",
                column: "FornecedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_VendedorId",
                table: "Produto",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VendedorId",
                table: "Venda",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_CarrinhoId",
                table: "VendaItens",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_ProdutoId",
                table: "VendaItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_VendaId",
                table: "VendaItens",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_VendedorId",
                table: "VendaItens",
                column: "VendedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteEndereco");

            migrationBuilder.DropTable(
                name: "FornecedorEndereco");

            migrationBuilder.DropTable(
                name: "VendaItens");

            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
