using Estoque.Test.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;
using Xunit;

namespace Estoque.Test.ValidationViewModelTests
{
    
    public class FornecedorViewModelTests
    {
        private readonly FornecedorEnderecoViewModelBuilder _builder;
        private readonly FornecedorEnderecoValidador _validator;

        public FornecedorViewModelTests()
        {
            var provider = new ServiceCollection().AddScoped<FornecedorEnderecoValidador>().BuildServiceProvider();

            _builder = new FornecedorEnderecoViewModelBuilder();
            _validator = provider.GetService<FornecedorEnderecoValidador>();
        }

        [Fact(DisplayName = "A classe deve ser válida")]
        public async Task ClasseValida()
        {
            var instancia = _builder.Build();

            var validationResult = await _validator.ValidateAsync(instancia);

            Assert.True(validationResult.IsValid);
        }
        #region Email
        [Fact(DisplayName = "O Email pode ser vazio")]
        public async Task EmailPodeSerVazio()
        {
            var instancia = _builder.With(a => a.Email = "" ).Build();

            var validationResult = await _validator.ValidateAsync(instancia);

            Assert.True(validationResult.IsValid);
        }

        [Theory(DisplayName = "Validar tipos diferentes de emails válidos")]
        [InlineData("a@a.com")]
        [InlineData("joao@maria.com")]
        [InlineData("marcio@nizzola.com.br")]
        public async Task EmailsValidos(string email)
        {
            var instancia = _builder.With(a => a.Email = email).Build();

            var validationResult = await _validator.ValidateAsync(instancia);

            Assert.True(validationResult.IsValid);
        }

        [Theory(DisplayName = "Validar emails incorretos")]
        [InlineData("aa.com")]
        [InlineData("@maria.com")]
        [InlineData("1")]
        public async Task EmailsInvalidos(string email)
        {
            var instancia = _builder.With(a => a.Email = email).Build();

            var validationResult = await _validator.ValidateAsync(instancia);

            Assert.False(validationResult.IsValid);
            Assert.Contains(validationResult.Errors, x => x.ErrorMessage.Contains(MensagensErroFornecedor.EmailFormatoInvalido));
        }

        [Fact(DisplayName = "O email não pode exceder 80 caracteres")]
        public async Task EmailExcedeuTamanho()
        {
            var instancia = _builder.With(a => a.Email = "012345678900123456789001234567890012345678900123456789001234567890012345678900123456789001234567890").Build();

            var validationResult = await _validator.ValidateAsync(instancia);

            Assert.False(validationResult.IsValid);
            Assert.Contains(validationResult.Errors, x => x.ErrorMessage.Contains(MensagensErroFornecedor.EmailTamanhoMaximo));
        }
        #endregion

        #region Telefone
        [Theory(DisplayName ="Telefones válidos!")]
        [InlineData("(11)99332-4966")]
        [InlineData("(11)93232-4776")]
        [InlineData("(11)94332-4886")]
        [InlineData("(11)24322-8756")]
        [InlineData("(11)95448-4153")]
        [InlineData("(11)75943-3428")]
        public async Task TelefoneValido(string telefone)
        {
            var instancia = _builder.With(a => a.Telefone = telefone).Build();
            var validatioResult = await _validator.ValidateAsync(instancia);

            Assert.True(validatioResult.IsValid);
        }
        [Theory(DisplayName = "Telefones não válidos!")]
        [InlineData("(11)993-4966")]
        [InlineData("(11)9332-4776")]
        [InlineData("(11)94332-886")]
        [InlineData("(11)24322-856")]
        [InlineData("(1)95444153")]
        [InlineData("(1175943-3428")]
        [InlineData("")]
        public async Task TelefoneNaoValido(string telefone)
        {
            var instancia = _builder.With(a => a.Telefone = telefone).Build();
            var validatioResult = await _validator.ValidateAsync(instancia);

            Assert.False(validatioResult.IsValid);
        }
        #endregion
        [Theory(DisplayName ="Cnpj válidos")]
        [InlineData("01.222.333/0001-99")]
        public async Task CnpjValido(string cnpj)
        {
            var instancia = _builder.With(a => a.Cnpj = cnpj).Build();

            var validationResult = await _validator.ValidateAsync(instancia);

            Assert.True(validationResult.IsValid);
        }
    }
}
