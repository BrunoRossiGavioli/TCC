using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using TCCESTOQUE.ViewModel;

namespace Estoque.Test.Builder
{
    public class FornecedorEnderecoViewModelBuilder : BuilderBase<FornecedorEnderecoViewModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<FornecedorEnderecoViewModel>.CreateNew()
                .With(x => x.Telefone = "(11)99858-5826")
                .With(x => x.Cnpj = "01.222.333/0001-99")
                .With(x => x.Email = "mail@mail.com")
                .With(x => x.NomeFantasia = "Nome do Fornecedor")
                .With(x => x.Bairro = "Bairro central")
                .With(x => x.Cep = "12.345-678")
                .With(x => x.Complemento = "xxx complemento")
                .With(x => x.Localidade = "Cidade xxx")
                .With(x => x.NomeFantasia = "Nome fantasia")
                .With(x => x.Logradouro = "logradouro")
                .With(x => x.Numero = 1)
                .With(x => x.RazaoSocial = "Marcolino pereira");
        }
    }
}
