using System.Collections.Generic;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        public ICollection<ProdutoModel> GetAll();

        public ProdutoModel GetOne(int? id);

        public void PostCriacao(ProdutoModel produtoModel);

        public ProdutoModel GetEdicao(int? id);

        public void PutEdicao(ProdutoModel produtoModel);

        public void PostExclusao(ProdutoModel produtoModel);
    }
}
