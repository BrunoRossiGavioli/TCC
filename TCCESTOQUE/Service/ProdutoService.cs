using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.Validacao.ValidacaoModels.ValidaEdit;
using TCCESTOQUE.ViewModel.EditViewModels;

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

        public ProdutoEditViewModel GetEdicao(int? id)
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

        public bool PostCriacao(ProdutoModel produtoModel)
        {
            var validador = new ProdutoValidador().Validate(produtoModel);
            if (validador.IsValid)
            {
                produtoModel = FormataValores.FormataValoresProdutoModel(produtoModel);
                return _produtoRepository.PostCriacao(produtoModel);
            }


            return false;
        }

        public object PostExclusao(int id)
        {
            return _produtoRepository.PostExclusao(id);
        }

        public bool PutEdicao(int id, ProdutoEditViewModel produtoModel)
        {
            if (produtoModel.ProdutoId == 0)
                produtoModel.ProdutoId = id;

            var validador = new ProdutoEditValidador().Validate(produtoModel);
            if (validador.IsValid)
                return _produtoRepository.PutEdicao(id, produtoModel);

            return false;
        }

        public VendedorModel GetByIdVendedor(int id)
        {
            return _produtoRepository.GetByIdVendedor(id);
        }
    }
}
