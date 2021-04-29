using System.Collections.Generic;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaService : IBaseService<VendaModel>
    {
        public object PostCricao(VendaViewModel venda);

        public object GetCriacao(int id);
        
        public object PutEdicao(int id, VendaModel venda);
    }
}
