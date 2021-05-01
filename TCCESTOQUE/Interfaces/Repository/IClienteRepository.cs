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
        public ICollection<ClienteModel> GetIndex();

        public ClienteModel GetOne(int? id);

        public void PostCriacao(ClienteModel cliente);

        public ClienteModel GetEdicao(int? id);

        public void PutEdicao(ClienteModel cliente);

        public void PostExclusao(ClienteModel cliente);
    }
}
