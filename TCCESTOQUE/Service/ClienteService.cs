using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.Validacao.ValidacaoModels.ValidaEdit;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public ClienteModel GetDetalhes(int? id)
        {
            return _clienteRepository.GetDetalhes(id);
        }

        public ClienteEditViewModel GetEdicao(int? id)
        {
            return _clienteRepository.GetEdicao(id);
        }

        public ClienteModel GetExclusao(int? id)
        {
            return _clienteRepository.GetExclusao(id);
        }

        public object GetIndex()
        {
            return _clienteRepository.GetIndex();
        }

        public object PostCriacao(ClienteViewModel cliente, int vendedorId)
        {
            var validacao = new ClienteValidador().Validate(cliente);

            if (validacao.IsValid)
            {
                cliente = FormataValores.FormataValoresClienteView(cliente);
                return _clienteRepository.PostCriacao(cliente);
            }
            if (cliente.VendedorId != vendedorId)
                return null;
            return null;

        }

        public object PostExclusao(int id)
        {
            return _clienteRepository.PostExclusao(id);
        }

        public object PutEdicao(int id, ClienteEditViewModel cliente, int vendedorId)
        {
            if (cliente.VendedorId != vendedorId)
                return null;
            var validacao = new ClienteEditValidador(_clienteRepository).Validate(cliente);
            if (!validacao.IsValid)
                return null;

            return _clienteRepository.PutEdicao(id, cliente);
        }
    }
}
