using Estoque.Test.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Repository;
using TCCESTOQUE.StartupOptions;
using TCCESTOQUE.Validacao.Business;
using TCCESTOQUE.Validacao.ValidacaoModels;
using Xunit;

namespace Estoque.Test.ServiceModelTests
{
    public class FornecedorModelBusinessValidatorTest
    {
        public ServiceCollection _serviceCollection { get; private set; }
        private readonly FornecedorModelBuilder _builder;
        private readonly IFornecedorRepository _repository;
        private readonly FornecedorModelBusinessValidator _validator;

        public FornecedorModelBusinessValidatorTest()
        {
            _builder = new FornecedorModelBuilder();

            _serviceCollection = new ServiceCollection();
            ConfigureDI.ConfigureServicesAndRepo(_serviceCollection);
            ConfigureDI.ConfigureAutoMapper(_serviceCollection);
            _serviceCollection.AddScoped<FornecedorModelBusinessValidator>().BuildServiceProvider();
            _serviceCollection.AddDbContext<TCCESTOQUEContext>(opt => opt.UseInMemoryDatabase("TccEstoque"));

            var provider = _serviceCollection.BuildServiceProvider();
            _validator = provider.GetService<FornecedorModelBusinessValidator>();
            _repository = provider.GetService<IFornecedorRepository>();
        }

        [Fact(DisplayName = "O fornecedor não deve aceitar dois emails iguais")]
        public void FornecedorNaoAceitaEmailRepetido()
        {
            var fornecedor = _builder.Build();

            var res = _repository

            var validationResult = _validator.Validate(fornecedor);

            Assert.True(validationResult.IsValid);
        }

    }
}
