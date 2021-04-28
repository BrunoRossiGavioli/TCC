using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using TCCESTOQUE.Models;

namespace Estoque.Test.Builder
{
    public class FornecedorModelBuilder : BuilderBase<FornecedorModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<FornecedorModel>.CreateNew()
                .With(x => x.Telefone = "(11)99858-5826")
                .With(x => x.Cnpj = "01.222.333/0001-99")
                .With(x => x.Email = "mail@mail.com")
                .With(x => x.NomeFantasia = "Nome do Fornecedor")
                .With(x => x.RazaoSocial = "Razao social");
        }
    }
}
