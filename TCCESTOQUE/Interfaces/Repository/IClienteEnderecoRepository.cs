using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IClienteEnderecoRepository
    {
        public void PostCriacao(ClienteEnderecoModel endereco);

        public void PutEdicao(ClienteEnderecoModel endereco);

        public ClienteEnderecoModel GetEnderecoByClienteId(ClienteModel cliente);
    }
}
