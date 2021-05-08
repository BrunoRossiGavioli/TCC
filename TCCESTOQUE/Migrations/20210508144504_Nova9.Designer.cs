﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCCESTOQUE.Data;

namespace TCCESTOQUE.Migrations
{
    [DbContext(typeof(TCCESTOQUEContext))]
    [Migration("20210508144504_Nova9")]
    partial class Nova9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TCCESTOQUE.Models.CarrinhoModel", b =>
                {
                    b.Property<Guid>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("CarrinhoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.ClienteEnderecoModel", b =>
                {
                    b.Property<Guid>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(9) CHARACTER SET utf8mb4")
                        .HasMaxLength(9);

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasMaxLength(6);

                    b.Property<int>("Uf")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("ClienteEndereco");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.ClienteModel", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.EntradaModel", b =>
                {
                    b.Property<Guid>("EntradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Cancelada")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("CustoProduto")
                        .HasColumnType("decimal(12,2)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("PrecoProduto")
                        .HasColumnType("decimal(12,2)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("char(36)");

                    b.Property<double>("QuantidadeProduto")
                        .HasColumnType("double");

                    b.Property<int>("UnidadeMedida")
                        .HasColumnType("int");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("EntradaId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.FornecedorEnderecoModel", b =>
                {
                    b.Property<Guid>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(9) CHARACTER SET utf8mb4")
                        .HasMaxLength(9);

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasMaxLength(6);

                    b.Property<int>("Uf")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.HasIndex("FornecedorId")
                        .IsUnique();

                    b.ToTable("FornecedorEndereco");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.FornecedorModel", b =>
                {
                    b.Property<Guid>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(18) CHARACTER SET utf8mb4")
                        .HasMaxLength(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4")
                        .HasMaxLength(14);

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("FornecedorId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.ProdutoModel", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<double>("Quantidade")
                        .HasColumnType("double");

                    b.Property<int>("UnidadeMedida")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(12,2)");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.VendaItensModel", b =>
                {
                    b.Property<Guid>("VendaItensId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CarrinhoId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("CustoProduto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PrecoProduto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<Guid?>("VendaId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("VendaItensId");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.HasIndex("VendedorId");

                    b.ToTable("VendaItens");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.VendaModel", b =>
                {
                    b.Property<Guid>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Cancelada")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("VendedorId")
                        .HasColumnType("char(36)");

                    b.HasKey("VendaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.VendedorModel", b =>
                {
                    b.Property<Guid>("VendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(14) CHARACTER SET utf8mb4")
                        .HasMaxLength(14);

                    b.HasKey("VendedorId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("TCCESTOQUE.Models.CarrinhoModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.ClienteEnderecoModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.ClienteModel", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("TCCESTOQUE.Models.ClienteEnderecoModel", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.ClienteModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.EntradaModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.FornecedorModel", "Fornecedor")
                        .WithMany("Entradas")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TCCESTOQUE.Models.ProdutoModel", "Produto")
                        .WithMany("Entradas")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.FornecedorEnderecoModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.FornecedorModel", "Fornecedor")
                        .WithOne("Endereco")
                        .HasForeignKey("TCCESTOQUE.Models.FornecedorEnderecoModel", "FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.FornecedorModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.ProdutoModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.VendaItensModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.CarrinhoModel", "Carrinho")
                        .WithMany("Itens")
                        .HasForeignKey("CarrinhoId");

                    b.HasOne("TCCESTOQUE.Models.ProdutoModel", "Produto")
                        .WithMany("Itens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCCESTOQUE.Models.VendaModel", "Venda")
                        .WithMany("Itens")
                        .HasForeignKey("VendaId");

                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TCCESTOQUE.Models.VendaModel", b =>
                {
                    b.HasOne("TCCESTOQUE.Models.ClienteModel", "Cliente")
                        .WithMany("Venda")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TCCESTOQUE.Models.VendedorModel", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
