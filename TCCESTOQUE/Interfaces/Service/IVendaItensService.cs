using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaItensService : IBaseService<VendaItensModel>
    {
        
        public object PostCriacao(VendaItensModel vendaItens, int id);

        public object PutEdicao(int? id, VendaItensModel vendaItens);

        
    }
}
