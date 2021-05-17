using FluentValidation.Results;
using System;
using System.Collections.Generic;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
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

        public ICollection<ProdutoModel> GetAll(Guid vendedorId)
        {
            return _produtoRepository.GetAll(vendedorId);
        }

        public ProdutoModel GetOne(Guid? id)
        {
            if (id == null)
                return null;

            return _produtoRepository.GetOne(id);
        }

        public ProdutoModel GetEdicao(Guid? id)
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
  produtoModel = FormataValores.FormataProduto(produtoModel);
            
            _produtoRepository.PostCriacao(produtoModel);
            return validador;
        }

        public bool PostExclusao(Guid id)
        {
            var produto = _produtoRepository.GetOne(id);
            if (produto == null)
                return false;
            produto.Inativo = true;
            _produtoRepository.PutEdicao(produto);
            return true;
        }

        public ValidationResult PutEdicao(ProdutoModel produtoModel)
        {
           
            produtoModel.Nome.ToUpper().Trim();
            var validador = new ProdutoValidador(true).Validate(produtoModel);
            if (!validador.IsValid)
                return validador;
                 produtoModel = FormataValores.FormataProduto(produtoModel);
            _produtoRepository.PutEdicao(ConvertProduto(produtoModel));
            return validador;
        }

        public ProdutoModel ConvertProduto(ProdutoModel produto)
        {
            var info = GetOne(produto.ProdutoId);
            info.ValorUnitario = produto.ValorUnitario;
            info.UnidadeMedida = produto.UnidadeMedida;
            info.Nome = produto.Nome;
            info.Descricao = produto.Descricao;
            info.Custo = produto.Custo;
            return info;
        }
    }
}
