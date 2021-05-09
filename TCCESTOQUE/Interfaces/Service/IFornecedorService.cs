using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.Models.Enum;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService : IBaseService<FornecedorModel>
    {
        public ValidationResult PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(Guid? id);

        public ValidationResult PutEditFull(Guid id, FornecedorEnderecoViewModel feviewmodel);

        public object PostExclusao(Guid id);
    }
}
