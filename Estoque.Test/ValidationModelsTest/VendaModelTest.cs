using Estoque.Test.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TCCESTOQUE.Validacao.ValidacaoModels;

namespace Estoque.Test.ValidationModelsTest
{
    public class VendaModelTest
    {
        private readonly VendaModelBuilder _builder;
        private readonly VendaValidador _validator;
        public VendaModelTest()
        {
            var provider = new ServiceCollection().AddScoped<VendaValidador>().BuildServiceProvider();
            _builder = new VendaModelBuilder();
            _validator = provider.GetService<VendaValidador>();
        }
    }
}
