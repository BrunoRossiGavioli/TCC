using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.Validacao.Formatacao; 

namespace TCCESTOQUE.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly TCCESTOQUEContext _context;

        public ProdutoRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public object GetIndex()
        {
            var tCCESTOQUEContext = _context.ProdutoModel.Include(p => p.Fornecedor);
            return tCCESTOQUEContext.ToList();
        }

        public object GetCriacao() 
        {
            return _context.ProdutoModel.ToList();
        }

        public ProdutoModel GetDetalhes(int? id)
        {
            if (id == null)
                return null;

            var produtoModel = _context.ProdutoModel
                .FirstOrDefault(m => m.Id == id);

            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public ProdutoModel GetEdicao(int? id)
        {
            if (id == null)
                return null;

            var produtoModel = _context.ProdutoModel.Find(id);
            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public ProdutoModel GetExclusao(int? id)
        {
            if (id == null)
                return null;

            var produtoModel = _context.ProdutoModel
                .FirstOrDefault(m => m.Id == id);

            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public bool PostCriacao(ProdutoModel produtoModel)
        {
                var validacao = new ProdutoValidador().Validate(produtoModel);
                if(validacao.IsValid)
                {
                produtoModel = FormataValores.FormataValoresProduto(produtoModel);
                _context.Add(produtoModel);
                _context.SaveChanges();
                return true;
                }
            return false;
        }

        public object PostExclusao(int id)
        {
            var produtoModel = _context.ProdutoModel.Find(id);
            _context.ProdutoModel.Remove(produtoModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public bool PutEdicao(int id, ProdutoModel produtoModel)
        {
            if (produtoModel.Id == 0)
                produtoModel.Id = id;
            var validacao = new ProdutoValidador().Validate(produtoModel);
            if(validacao.IsValid)
            {
                try
                {
                    produtoModel = FormataValores.FormataValoresProduto(produtoModel);  
                    _context.Update(produtoModel);
                    _context.SaveChanges();
                    return true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
            }
            
            return false;
           
        }
    }
}
