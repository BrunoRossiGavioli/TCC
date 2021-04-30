using FluentValidation.Results;
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
            if (id == null)
                return null;

            return _produtoRepository.GetDetalhes(id);
        }

        public ProdutoModel GetEdicao(int? id)
        {
            if (id == null)
                return null;

            return _produtoRepository.GetEdicao(id);
        }

        public ProdutoModel GetExclusao(int? id)
        {
            if (id == null)
                return null;

            return _produtoRepository.GetExclusao(id);
        }

        public ValidationResult PostCriacao(ProdutoModel produtoModel)
        {
            var validador = new ProdutoValidador().Validate(produtoModel);
            if (!validador.IsValid)
                return validador;
                    
            _produtoRepository.PostCriacao(produtoModel);
            return validador;
        }

        public object PostExclusao(int id)
        {
            return _produtoRepository.PostExclusao(id);
        }

        public ValidationResult PutEdicao(int id, ProdutoModel produtoModel)
        {
            produtoModel.ProdutoId = id;
            var validador = new ProdutoValidador().Validate(produtoModel);
            if (!validador.IsValid)
                return validador;

            _produtoRepository.PutEdicao(id, produtoModel);
            return validador;
        }
    }
}
