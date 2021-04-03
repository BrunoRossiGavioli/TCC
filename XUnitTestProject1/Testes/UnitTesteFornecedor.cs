using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.ValidaModels;
using Xunit;

namespace XUnitTestProject1
{
    public class UintTesteFornecedor
    {
      private FornecedorModel fornecedor;

        public UintTesteFornecedor()
        {
            fornecedor = new FornecedorModel()
            {
                Nome = "Carlos",
                NomeFantasia = "Carlos Da empresa",
                Email = "carlos@gmail.com",
                DataNascimento = DateTime.Today.AddYears(-18),
                Endereco = "Rua dos de buenos aires 123",
                Telefone = "11122222222", 
                Cnpj = "11122222233323"
            };
        }
    
        

        [Fact]
        public void ObjetoDeveSerValido()
        {
            var validador = new FornecedorValidador();
            var result = validador.Validate(fornecedor);

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
                var validador = new FornecedorValidador();
                fornecedor.Nome = nome;
                var result = validador.Validate(fornecedor);

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
                var validador = new FornecedorValidador();
                fornecedor.Nome = nome;
                var result = validador.Validate(fornecedor);

                Assert.True(result.IsValid);
            }
    #endregion

    #region NomeFantasia
            [Theory(DisplayName = "Teste de Nome Fantasia Inválidos")]
            [InlineData("a")]
            [InlineData("b")]
            [InlineData("aa")]
            [InlineData("js")]
            [InlineData("")]
            public void NomeFantasiaNaoDeveSerValido(string nome)
            {
                var validador = new FornecedorValidador();
                fornecedor.NomeFantasia = nome;
                var result = validador.Validate(fornecedor);

                Assert.False(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Nome Válidos")]
            [InlineData("José")]
            [InlineData("Paula")]
            [InlineData("João")]
            [InlineData("Carla")]
            [InlineData("Ana")]
            public void NomeFantasiaDeveSerValido(string nome)
            {
                var validador = new FornecedorValidador();
                fornecedor.NomeFantasia = nome;
                var result = validador.Validate(fornecedor);

                Assert.True(result.IsValid);
            }
            #endregion
    
    #region  Email
            [Theory(DisplayName = "Teste de Emails inválidos")]
            [InlineData("aaaaa")]
            [InlineData("aaaaa@")]
            [InlineData("@aaaaa")]
            [InlineData("aaaaa.com")]
            [InlineData("")]
            public void EmailNaoDeveSerValido(string email)
            {
                var validador = new FornecedorValidador();
                fornecedor.Email = email;
                var result = validador.Validate(fornecedor);

                Assert.False(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Emails Válidos")]
            [InlineData("joao@gmail.com")]
            [InlineData("paula@gmail.com")]
            [InlineData("jose@gmail.com")]
            [InlineData("carla@gmail.com")]
            public void EmailDeveSerValido(string email)
            {
                var validador = new FornecedorValidador();
                fornecedor.Email = email;
                var result = validador.Validate(fornecedor);

                Assert.True(result.IsValid);
            }
            #endregion

    #region Data De Nascimento

            [Theory(DisplayName = "Teste de Datas de Nascimento Válidas")]
            [InlineData("01/01/2003")]
            [InlineData("01/01/1980")]            
            public void DataDeveSerValida(string dataStr)
            {
                var validador = new FornecedorValidador();
                fornecedor.DataNascimento = DateTime.Parse(dataStr);
                var result = validador.Validate(fornecedor);

                Assert.True(result.IsValid);
            }

            [Theory(DisplayName = "Teste de datas de nascimento Inválidas")]
            [InlineData("01/01/2022")]
            [InlineData("01/01/4400")]            
            public void DataNaoDeveSerValida(string dataStr)
            {
                var validador = new FornecedorValidador();
                fornecedor.DataNascimento = DateTime.Parse(dataStr);
                var result = validador.Validate(fornecedor);

                Assert.False(result.IsValid);
            }
            [Theory(DisplayName = "Teste de datas de nascimento minimo de idade")]
            [InlineData("01/01/2019")]
            [InlineData("01/01/2020")]
            [InlineData("01/01/2021")]
            public void MinimoDeIdadeNaoValido(string dataStr)
            {
                var validador = new FornecedorValidador();
                fornecedor.DataNascimento = DateTime.Parse(dataStr);
                var result = validador.Validate(fornecedor);

                Assert.False(result.IsValid);
            }
            #endregion
        
    #region Endereço
        [Theory(DisplayName = "Teste de Endereço inválidos")]
        [InlineData("a123")]
        [InlineData("b123 ")]
        [InlineData("aaaa")]
        [InlineData("oqwewqeqs")]
        [InlineData("")]
        public void EnderecoNaoDeveSerValido(string endereco)
        {
            var validador = new FornecedorValidador();
            fornecedor.Endereco = endereco;
            var result = validador.Validate(fornecedor);

            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Endereço Válido")]
        [InlineData("Rua Afonso Guido 193")]
        [InlineData("Rua Puiz Parlos Pires 444")]
        [InlineData("SÃO JOSE DE ALAMEDA 321")]
        [InlineData("JOSEMAR DOS CAMPOS GRANDES 765")]
        public void EnderecoDeveSerValido(string endereco)
        {
            var validador = new FornecedorValidador();
            fornecedor.Endereco = endereco;
            var result = validador.Validate(fornecedor);

            Assert.True(result.IsValid);
        }
    #endregion

    #region Telefone
        [Theory(DisplayName = "Teste de Telefone Inválidos")]
        [InlineData("11111111")]
        [InlineData("1231")]
        [InlineData("11111")]
        [InlineData("123456786")]
        [InlineData("")]
        public void TelefoneNaoDeveSerValido(string telefone)
        {
            var validador = new FornecedorValidador();
            fornecedor.Telefone = telefone;
            var result = validador.Validate(fornecedor);

            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Telefone Válidos")]
        [InlineData("11293745826")]
        [InlineData("11847639472")]
        [InlineData("11242674596")]
        [InlineData("11039483905")]
        public void TelefoneDeveSerValido(string telefone)
        {
            var validador = new FornecedorValidador();
            fornecedor.Telefone = telefone;
            var result = validador.Validate(fornecedor);

            Assert.True(result.IsValid);
        }

    #endregion
   
    #region Cnpj
        [Theory(DisplayName = "Teste de Cnpj Válidos")]
        [InlineData("22222222232343")]
        [InlineData("56422222222222")]
        [InlineData("87719394297293")]
        [InlineData("95542342123123")]
        public void CnpjDeveSerValido(string cnpj)
        {
            var validador = new FornecedorValidador();
            fornecedor.Cnpj = cnpj;
            var result = validador.Validate(fornecedor);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Cnpj Inválidos")]
        [InlineData("1")]
        [InlineData("12313134")]
        [InlineData("4444444444444")]
        [InlineData("44444444444444234234")]
        [InlineData("eferrf")]
        [InlineData("efeef")]
        [InlineData("")]
        public void CnpjNaoDeveSerValido(string cnpj)
        {
            var validador = new FornecedorValidador();
            fornecedor.Cnpj = cnpj;
            var result = validador.Validate(fornecedor);

            Assert.False(result.IsValid);
        }
    #endregion
    }
}
