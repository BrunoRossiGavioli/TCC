using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IProdutoService
    {
        public object GetIndex();

        public ProdutoModel GetDetalhes(int? id);

        public object GetCriacao();

        public object PostCriacao(ProdutoModel produtoModel);

        public ProdutoModel GetEdicao(int? id);

        public object PutEdicao(int id, ProdutoModel produtoModel);

        public ProdutoModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
