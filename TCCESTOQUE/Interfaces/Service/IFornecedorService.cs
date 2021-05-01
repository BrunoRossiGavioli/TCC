using FluentValidation.Results;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService : IServiceBase<FornecedorModel>
    {
        public ValidationResult PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(int? id);

        public ValidationResult PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel);
    }
}
