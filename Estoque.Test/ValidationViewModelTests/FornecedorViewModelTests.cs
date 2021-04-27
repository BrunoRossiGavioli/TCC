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
    }
}
