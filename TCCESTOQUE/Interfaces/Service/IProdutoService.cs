using FluentValidation.Results;
using System;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IProdutoService : IBaseService<ProdutoModel>
    {
        public ValidationResult PostCriacao(ProdutoModel produtoModel);

        public ValidationResult PutEdicao(ProdutoModel produtoModel);

<<<<<<< HEAD
        public ProdutoModel GetEdicao(Guid? id);
=======
        public ProdutoModel GetEdicao(int? id);

        public bool PostExclusao(int id);
>>>>>>> 2f52e926b313da0a5fe6427d67fd5779177e9a86
    }
}
