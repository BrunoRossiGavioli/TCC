using FluentValidation.Results;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IProdutoService
    {
        public object GetIndex();

        public ProdutoModel GetDetalhes(int? id);

        public object GetCriacao();

        public ValidationResult PostCriacao(ProdutoModel produtoModel);

        public ProdutoModel GetEdicao(int? id);

        public ValidationResult PutEdicao(int id, ProdutoModel produtoModel);

        public ProdutoModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
