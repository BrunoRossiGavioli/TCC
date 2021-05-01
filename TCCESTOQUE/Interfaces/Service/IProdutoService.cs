using FluentValidation.Results;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IProdutoService : IServiceBase<ProdutoModel>
    {
        public ValidationResult PostCriacao(ProdutoModel produtoModel);

        public ValidationResult PutEdicao(ProdutoModel produtoModel);

        public ProdutoModel GetEdicao(int? id);
    }
}
