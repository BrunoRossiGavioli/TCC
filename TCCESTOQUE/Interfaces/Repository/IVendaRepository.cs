using System.Collections.Generic;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendaRepository
    {
        public ICollection<VendaModel> GetIndex();
        public VendaModel GetDetalhes(int? id);

        public object PostCricao(VendaViewModel venda);

        public object GetCricao(int id);

        public VendaModel GetEdicao(int? id);

        public object PutEdicao(int id, VendaModel venda);

        public VendaModel GetExclusao(int? id);

        public VendaModel PostExclusao(int id);
    }
}
