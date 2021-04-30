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

        public void PostCriacao(ProdutoModel produtoModel)
        {
            _context.Add(produtoModel);
            _context.SaveChanges();   
        }

        public object PostExclusao(int id)
        {
            var produtoModel = _context.ProdutoModel.Find(id);
            _context.ProdutoModel.Remove(produtoModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public void PutEdicao(int id, ProdutoModel produtoModel)
        {
            _context.Update(produtoModel);
            _context.SaveChanges();   
        }
    }
}
