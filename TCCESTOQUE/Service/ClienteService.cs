using AutoMapper;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public ClienteModel GetDetalhes(int? id)
        {
            return _clienteRepository.GetDetalhes(id);
        }

        public ClienteViewModel GetEdicao(int? id)
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

        public object PutEdicao(int id, ClienteViewModel cliente, int vendedorId)
        {
            if (cliente.VendedorId != vendedorId)
                return null;
           // var mapeamento = _mapper.Map<ClienteModel>(cliente);
            var validacao = new ClienteValidador().Validate(cliente);
            if (!validacao.IsValid)
                return null;

            return _clienteRepository.PutEdicao(id, cliente);
        }
    }
}
