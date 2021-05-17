using FizzWare.NBuilder;
using System;
using TCCESTOQUE.Models;

namespace Estoque.Test.Builder
{
    public class ProdutoModelBuilder : BuilderBase<ProdutoModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<ProdutoModel>.CreateNew()
                .With(x => x.Custo = Convert.ToDecimal(12.00))
                .With(x => x.Nome = "Cleberson")
                .With(x => x.ValorUnitario = Convert.ToDecimal(12.00))
                .With(x => x.Quantidade = 40);
        }
    }
}
