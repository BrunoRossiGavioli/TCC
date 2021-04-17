using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

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
            var res  = new SelectList(_context.FornecedorModel, "FornecedorId", "NomeFantasia");
            return res;
        }

        public ProdutoModel GetDetalhes(int? id)
        {
            var produtoModel = _context.ProdutoModel
                .FirstOrDefault(m => m.ProdutoId == id);

            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public ProdutoModel GetEdicao(int? id)
        {
            var produtoModel = _context.ProdutoModel.Find(id);
            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public ProdutoModel GetExclusao(int? id)
        {
            var produtoModel = _context.ProdutoModel
                .FirstOrDefault(m => m.ProdutoId == id);

            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public bool PostCriacao(ProdutoModel produtoModel)
        {
            try
            {
                _context.Add(produtoModel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }       
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
            try
            {
                _context.Update(produtoModel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
