using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public object GetIndex()
        {
            return _produtoRepository.GetIndex();
        }

        public object GetCriacao()
        { 
            return _produtoRepository.GetCriacao();
        }

        public ProdutoModel GetDetalhes(int? id)
        {
            return _produtoRepository.GetDetalhes(id);
        }

        public ProdutoModel GetEdicao(int? id)
        {
            return _produtoRepository.GetEdicao(id);
        }

        public ProdutoModel GetExclusao(int? id)
        {
            return _produtoRepository.GetExclusao(id);
        }

        public bool PostCriacao(ProdutoModel produtoModel)
        {
            return _produtoRepository.PostCriacao(produtoModel);
        }

        public object PostExclusao(int id)
        {
            return _produtoRepository.PostExclusao(id);
        }

        public bool PutEdicao(int id, ProdutoModel produtoModel)
        {
            return _produtoRepository.PutEdicao(id, produtoModel);
        }
    }
}
