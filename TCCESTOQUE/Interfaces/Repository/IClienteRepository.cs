using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IClienteRepository
    {
        public object GetIndex();

        public ClienteModel GetDetalhes(int? id);

        public object PostCriacao(ClienteModel cliente);

        public ClienteModel GetEdicao(int? id);

        public object PutEdicao(int id, ClienteModel cliente);

        public ClienteModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
