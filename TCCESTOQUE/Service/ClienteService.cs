using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

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

        public ClienteModel GetEdicao(int? id)
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

        public object PostCriacao(ClienteModel cliente, int vendedorId)
        {
            if (cliente.VendedorId != vendedorId)
                return null;

            return _clienteRepository.PostCriacao(cliente);
        }

        public object PostExclusao(int id)
        {
            return _clienteRepository.PostExclusao(id);
        }

        public object PutEdicao(int id, ClienteModel cliente, int vendedorId)
        {
            if (cliente.VendedorId != vendedorId)
                return null;
            return _clienteRepository.PutEdicao(id, cliente);
        }
    }
}
