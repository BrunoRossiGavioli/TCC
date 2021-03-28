using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.ValidadorVendedor;
using Xunit;

namespace XUnitTestProject1
{
    public class UintTesteVendedor
    {
      private VendedorModel vendedor;

        public UintTesteVendedor()
        {
            vendedor = new VendedorModel()
            {
                Nome = "Antônio",
                Email = "antônio@gmail.com",
                DataNascimento = DateTime.Today.AddYears(-18),
                Endereco = "Rua do carninha logo ali",
                Telefone = "(11)1232-12321",
                Senha = "sanknsajdn",
                Cpf = "213123133",
                Ativo = true,
                Logado = true
            };
        }
    
        

        [Fact]
        public void ObjetoDeveSerValido()
        {
            var validador = new ValidadorVendedor();
            var result = validador.Validate(vendedor);

            Assert.True(result.IsValid);
        }
    #region Nome
            [Theory(DisplayName = "Teste de Nome Inválidos")]
            [InlineData("a")]
            [InlineData("b")]
            [InlineData("aaaa")]
            [InlineData("jos")]
            public void NomeNaoDeveSerValido(string nome)
            {
                var validador = new ValidadorVendedor();
                vendedor.Nome = nome;
                var result = validador.Validate(vendedor);

                Assert.False(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Nome Válidos")]
            [InlineData("José")]
            [InlineData("Paula")]
            [InlineData("João")]
            [InlineData("Carla")]
            public void NomeDeveSerValido(string nome)
            {
                var validador = new ValidadorVendedor();
                vendedor.Nome = nome;
                var result = validador.Validate(vendedor);

                Assert.True(result.IsValid);
            }
    #endregion

    #region  Email
            [Theory(DisplayName = "Teste de Emails inválidos")]
            [InlineData("aaaaa")]
            [InlineData("aaaaa@")]
            [InlineData("@aaaaa")]
            [InlineData("aaaaa.com")]
            public void EmailNaoDeveSerValido(string email)
            {
                var validador = new ValidadorVendedor();
                vendedor.Email = email;
                var result = validador.Validate(vendedor);

                Assert.False(result.IsValid);
            }

            [Theory(DisplayName = "Teste de Emails Válidos")]
            [InlineData("joao@gmail.com")]
            [InlineData("paula@gmail.com")]
            [InlineData("jose@gmail.com")]
            [InlineData("carla@gmail.com")]
            public void EmailDeveSerValido(string email)
            {
                var validador = new ValidadorVendedor();
                vendedor.Email = email;
                var result = validador.Validate(vendedor);

                Assert.True(result.IsValid);
            }
            #endregion

    #region Data De Nascimento

            [Theory(DisplayName = "Teste de Datas de Nascimento Válidas")]
            [InlineData("01/01/2003")]
            [InlineData("01/01/1980")]
            public void DataDeveSerValida(string dataStr)
            {
                var validador = new ValidadorVendedor();
                vendedor.DataNascimento = DateTime.Parse(dataStr);
                var result = validador.Validate(vendedor);

                Assert.True(result.IsValid);
            }

            [Theory(DisplayName = "Teste de datas de nascimento Inválidas")]
            [InlineData("01/01/2022")]
            [InlineData("01/01/4400")]
            public void DataNaoDeveSerValida(string dataStr)
            {
                var validador = new ValidadorVendedor();
                vendedor.DataNascimento = DateTime.Parse(dataStr);
                var result = validador.Validate(vendedor);

                Assert.False(result.IsValid);
            }
            [Theory(DisplayName = "Teste de datas de nascimento minimo de idade")]
            [InlineData("01/01/2019")]
            [InlineData("01/01/2020")]
            [InlineData("01/01/2021")]
            public void MinimoDeIdadeNaoValido(string dataStr)
            {
                var validador = new ValidadorVendedor();
                vendedor.DataNascimento = DateTime.Parse(dataStr);
                var result = validador.Validate(vendedor);

                Assert.False(result.IsValid);
            }
            #endregion
        
    #region Endereço
        [Theory(DisplayName = "Teste de Endereço inválidos")]
        [InlineData("a123")]
        [InlineData("b123 ")]
        [InlineData("aaaa")]
        [InlineData("oqwewqeqs")]
        public void EnderecoNaoDeveSerValido(string endereco)
        {
            var validador = new ValidadorVendedor();
            vendedor.Endereco = endereco;
            var result = validador.Validate(vendedor);

            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Endereço Válido")]
        [InlineData("Rua Afonso Guido 193")]
        [InlineData("Rua Puiz Parlos Pires 444")]
        [InlineData("SÃO JOSE DE ALAMEDA 321")]
        [InlineData("JOSEMAR DOS CAMPOS GRANDES 765")]
        public void EnderecoDeveSerValido(string endereco)
        {
            var validador = new ValidadorVendedor();
            vendedor.Endereco = endereco;
            var result = validador.Validate(vendedor);

            Assert.True(result.IsValid);
        }
    #endregion

    #region Telefone
    [Theory(DisplayName = "Teste de Telefone inválidos")]
        [InlineData("11111-111)")]
        [InlineData("1231")]
        [InlineData("11111111")]
        [InlineData("12345678")]
        public void TelefoneNaoDeveSerValido(string telefone)
        {
            var validador = new ValidadorVendedor();
            vendedor.Telefone = telefone;
            var result = validador.Validate(vendedor);

            Assert.False(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Telefone Válidos")]
        [InlineData("11994483392")]
        [InlineData("11221123112")]
        [InlineData("11321543757")]
        [InlineData("11234234234")]
        public void TelefoneDeveSerValido(string telefone)
        {
            var validador = new ValidadorVendedor();
            vendedor.Telefone = telefone;
            var result = validador.Validate(vendedor);

            Assert.True(result.IsValid);
        }

    #endregion

    #region Senha
     [Theory(DisplayName = "Teste de Telefone Válidos")]
        [InlineData("1234567890")]
        [InlineData("njnvkjndnvkvn")]
        [InlineData("KKJNKNKKNKJJN")]
        [InlineData("kkkkiik4")]
        public void SenhaDeveSerValido(string senha)
        {
            var validador = new ValidadorVendedor();
            vendedor.Senha = senha;
            var result = validador.Validate(vendedor);

            Assert.True(result.IsValid);
        }

        [Theory(DisplayName = "Teste de Telefone Inválidos")]
        [InlineData("1")]
        [InlineData("123123")]
        [InlineData("wqeq")]
        [InlineData("sdv")]
        public void SenhaNaoDeveSerValido(string senha)
        {
            var validador = new ValidadorVendedor();
            vendedor.Senha = senha;
            var result = validador.Validate(vendedor);

            Assert.False(result.IsValid);
        }
    #endregion

    #region Cpf
     [Theory(DisplayName = "Teste de Cpf Válidos")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("19394297293")]
        [InlineData("42342123123")]
        public void CpfDeveSerValido(string cpf)
        {
            var validador = new ValidadorVendedor();
            vendedor.Cpf = cpf;
            var result = validador.Validate(vendedor);

            Assert.True(result.IsValid);
        }

         [Theory(DisplayName = "Teste de Cpf Inválidos")]
        [InlineData("1")]
        [InlineData("12313134")]
        [InlineData("eferrf")]
        [InlineData("efeef")]
        public void CpfNaoDeveSerValido(string cpf)
        {
            var validador = new ValidadorVendedor();
            vendedor.Cpf = cpf;
            var result = validador.Validate(vendedor);

            Assert.False(result.IsValid);
        }
    #endregion
    }
}