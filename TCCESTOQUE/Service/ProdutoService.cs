using FluentValidation.Results;
using System.Collections;
using System.Collections.Generic;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;

namespace TCCESTOQUE.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ICollection<ProdutoModel> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public ProdutoModel GetOne(int? id)
        {
            if (id == null)
                return null;

            return _produtoRepository.GetOne(id);
        }

        public ProdutoModel GetEdicao(int? id)
        {
            if (id == null)
                return null;

            return _produtoRepository.GetEdicao(id);
        }

        public ValidationResult PostCriacao(ProdutoModel produtoModel)
        {
            var validador = new ProdutoValidador().Validate(produtoModel);
            if (!validador.IsValid)
                return validador;
                    
            _produtoRepository.PostCriacao(produtoModel);
            return validador;
        }

        public bool PostExclusao(int id)
        {
            var produto = _produtoRepository.GetOne(id);
            if(produto != null)
            {
                _produtoRepository.PostExclusao(produto);
                return true;
            }
            return false;
        }

        public ValidationResult PutEdicao(ProdutoModel produtoModel)
        {
            var validador = new ProdutoValidador().Validate(produtoModel);
            if (!validador.IsValid)
                return validador;

            _produtoRepository.PutEdicao(produtoModel);
            return validador;
        }

        public bool BaixarEstoque(int produtoId, double quantidade)
        {

        }

        public bool AdicionarEstoque(int produtoId, double quantidade)
        {

        }
    }
}
