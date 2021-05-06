using FluentValidation.Results;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IClienteService : IBaseService<ClienteModel>
    {

        public ValidationResult PostCriacao(ClienteViewModel cliente);

        public ClienteViewModel GetEdicao(int? id);

        public ValidationResult PutEdicao(ClienteViewModel cliente);

        public bool PostExclusao(int id);
    }
}
