using FluentValidation.Results;
using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService : IBaseService<FornecedorModel>
    {
        public ValidationResult PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(Guid? id);

<<<<<<< HEAD
        public ValidationResult PutEditFull(Guid id, FornecedorEnderecoViewModel feviewmodel);
=======
        public ValidationResult PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel);

        public object PostExclusao(int id);
>>>>>>> 2f52e926b313da0a5fe6427d67fd5779177e9a86
    }
}
