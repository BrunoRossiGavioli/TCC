using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IClienteService
    {
        public object GetIndex();

        public ClienteModel GetDetalhes(int? id);

        public object PostCriacao(ClienteViewModel cliente,int vendedorId);

        public ClienteEditViewModel GetEdicao(int? id);

        public object PutEdicao(int id, ClienteEditViewModel cliente, int vendedorId);

        public ClienteModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
