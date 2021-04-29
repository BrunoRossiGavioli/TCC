using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IClienteService : IBaseService<ClienteModel>
    {
        public object PostCriacao(ClienteViewModel cliente, int vendedorId);

        public ClienteEditViewModel GetEdicao(int? id);

        public object PutEdicao(int id, ClienteEditViewModel cliente, int vendedorId);
        
    }
}
