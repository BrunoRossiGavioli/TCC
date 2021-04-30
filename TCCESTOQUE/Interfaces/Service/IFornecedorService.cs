using FluentValidation.Results;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService
    {
        public object GetIndex();

        public FornecedorModel GetDetalhes(int? id);

        public ValidationResult PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(int? id);

        public ValidationResult PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel);

        public FornecedorModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
