using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        public object GetCriacao();

        public bool PostCriacao(ProdutoModel produtoModel);

        public ProdutoEditViewModel GetEdicao(int? id);

        public bool PutEdicao(int id, ProdutoEditViewModel produtoModel);

        public VendedorModel GetByIdVendedor(int id);

    }
}
