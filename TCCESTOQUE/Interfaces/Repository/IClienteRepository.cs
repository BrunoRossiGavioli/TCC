using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IClienteRepository
    {
        public object GetIndex();

        public ClienteModel GetDetalhes(int? id);

        public object PostCriacao(ClienteViewModel cliente);

        public ClienteViewModel GetEdicao(int? id);

        public object PutEdicao(int id, ClienteViewModel cliente);

        public ClienteModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
