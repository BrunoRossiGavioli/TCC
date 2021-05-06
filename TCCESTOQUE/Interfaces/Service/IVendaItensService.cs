using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaItensService : IBaseService<VendaItensModel>
    {
        public bool PostItem(VendaItensModel vendaItens);

        public bool PutEdicao(VendaItensModel vendaItens);

        public bool PostExclusao(int id);
    }
}
