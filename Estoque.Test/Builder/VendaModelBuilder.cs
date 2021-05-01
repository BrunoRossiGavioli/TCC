using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using TCCESTOQUE.Models;

namespace Estoque.Test.Builder
{
    public class VendaModelBuilder : BuilderBase<VendaModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<VendaModel>.CreateNew()
                 .With(x => x.DataVenda = DateTime.Today)
                 .With(x => x.Valor = Convert.ToDecimal(10.00));
                 
        }
    }
}
