using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IClienteService
    {
        public object GetIndex();

        public ClienteModel GetDetalhes(int? id);

        public object PostCriacao(ClienteModel cliente,int vendedorId);

        public ClienteModel GetEdicao(int? id);

        public object PutEdicao(int id, ClienteModel cliente, int vendedorId);

        public ClienteModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
