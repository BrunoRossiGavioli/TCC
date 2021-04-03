using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;
using Xunit;

namespace XUnitTestTCCESTOQUE.Testes
{
    public class UintTesteProduto 
    {
      private ProdutoModel produto;

        public UintTesteProduto()
        {
            produto = new ProdutoModel()
            {
                Nome = "Antônio",
                Descricao = "Terra",
                Custo = Convert.ToDecimal(100.00),
                ValorUnitario = Convert.ToDecimal(10.00),
                Quantidade = Convert.ToInt32(10), 
                DataEntrada = DateTime.Now.AddMinutes(1)
            };
        }            

        [Fact]
        public void ObjetoDeveSerValido()
        {
            var validador = new ProdutoValidador();
            var result = validador.Validate(produto);

            Assert.True(result.IsValid);
        }
    #region Nome
            [Theory(DisplayName = "Teste de Nome Inválidos")]
            [InlineData("a")]
            [InlineData("b")]
            [InlineData("aa")]
            [InlineData("js")]
            [InlineData("")]
            public void NomeNaoDeveSerValido(string nome)
            {
                var validador = new ProdutoValidador();
                produto.Nome = nome;
                var result = validador.Validate(produto);

                Assert.False(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Nome Válidos")]
            [InlineData("José")]
            [InlineData("Paula")]
            [InlineData("João")]
            [InlineData("Carla")]
            [InlineData("Ana")]
            public void NomeDeveSerValido(string nome)
            {
                var validador = new ProdutoValidador();
                produto.Nome = nome;
                var result = validador.Validate(produto);

                Assert.True(result.IsValid);
            }
    #endregion

    #region  Descrição
            [Theory(DisplayName = "Teste de Descrições inválidas")]
            [InlineData("T")]
            [InlineData("A")]
            [InlineData("Ti")]
            [InlineData("")]
            public void DescricaoNaoDeveSerValido(string descricao)
            {
                var validador = new ProdutoValidador();
                produto.Descricao = descricao;
                var result = validador.Validate(produto);

                Assert.False(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Descrições Válidas")]
            [InlineData("Terra")]
            [InlineData("cal")]
            [InlineData("tijolo")]
            [InlineData("cimento")]
            public void DescricaoDeveSerValido(string descricao)
            {
                var validador = new ProdutoValidador();
                produto.Descricao = descricao;
                var result = validador.Validate(produto);

                Assert.True(result.IsValid);
            }
            #endregion

    #region Custo

            [Theory(DisplayName = "Teste de Custo Válidos")]
            [InlineData("1,00")]
            [InlineData("2,00")] 
            [InlineData("100,00")]            
            public void CustoDeveSerValida(string custo)
            {
                var validador = new ProdutoValidador();
                produto.Custo = Convert.ToDecimal(custo);
                var result = validador.Validate(produto);

                Assert.True(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Custo Inválido")]
            [InlineData("0,00")]            
            public void CustoNaoDeveSerValida(string custo)
            {
                var validador = new ProdutoValidador();
                produto.Custo = Convert.ToDecimal(custo);
                var result = validador.Validate(produto);

                Assert.False(result.IsValid);
            }
            #endregion
              
    #region Valor Unitario

            [Theory(DisplayName = "Teste de Valores Unitários Válidos")]
            [InlineData("1,00")]
            [InlineData("2,00")] 
            [InlineData("100,00")]            
            public void ValorUnitDeveSerValida(string valor)
            {
                var validador = new ProdutoValidador();
                produto.ValorUnitario = Convert.ToDecimal(valor);
                var result = validador.Validate(produto);

                Assert.True(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Valores Unitários Inválidos")]
            [InlineData("0,00")]            
            public void ValorUnitNaoDeveSerValida(string valor)
            {
                var validador = new ProdutoValidador();
                produto.ValorUnitario = Convert.ToDecimal(valor);
                var result = validador.Validate(produto);

                Assert.False(result.IsValid);
            }
            #endregion
          
    #region Quantidade

            [Theory(DisplayName = "Teste de Quantidades Válidas")]
            [InlineData("1")]
            [InlineData("2")] 
            [InlineData("10")]            
            public void QuantidadeDeveSerValida(string quant)
            {
                var validador = new ProdutoValidador();
                produto.Quantidade = Convert.ToInt32(quant);
                var result = validador.Validate(produto);

                Assert.True(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Quantidades Inválidas")]
            [InlineData("0")]            
            public void QuantidadeNaoDeveSerValida(string quant)
            {
                var validador = new ProdutoValidador();
                produto.Quantidade = Convert.ToInt32(quant);
                var result = validador.Validate(produto);

                Assert.False(result.IsValid);
            }
            #endregion
    
     #region Data de Entrada

            [Theory(DisplayName = "Teste de Datas de Entradas Válidas")]
            [InlineData("01/01/2019")]
            [InlineData("01/01/2020")]
            [InlineData("03/04/2021")]
            public void DataValida(string dataStr)
            {
                var validador = new ProdutoValidador();
                produto.DataEntrada = DateTime.Parse(dataStr);
                var result = validador.Validate(produto);

                Assert.True(result.IsValid);
            }
            [Theory(DisplayName = "Teste de Datas de Entradas Inválidas")]
            [InlineData("01/01/2222")]
            [InlineData("01/01/4404")]
            [InlineData("01/01/7675")]
            public void DataFuturaValida(string dataStr)
            {
                var validador = new ProdutoValidador();
                produto.DataEntrada = DateTime.Parse(dataStr);
                var result = validador.Validate(produto);

                Assert.False(result.IsValid);
            }
            #endregion
    }
}
