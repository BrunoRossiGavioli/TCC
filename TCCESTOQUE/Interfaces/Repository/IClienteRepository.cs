using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IClienteRepository
    {
        public object GetIndex();

        public ClienteModel GetDetalhes(int? id);

        public object PostCriacao(ClienteViewModel cliente);

        public ClienteEditViewModel GetEdicao(int? id);

        public object PutEdicao(int id, ClienteEditViewModel cliente);

        public ClienteModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public ClienteModel GetbyEmail(string email);
        public ClienteModel GetByPhone(string telefone);
        public ClienteModel GetByCpf(string cpf);
    }
}
