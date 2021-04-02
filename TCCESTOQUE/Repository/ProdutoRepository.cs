using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var res  = new SelectList(_context.FornecedorModel, "Id", "Nome");
            return res;
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

        public object PostCriacao(ProdutoModel produtoModel)
        {
            _context.Add(produtoModel);
            _context.SaveChanges();
            return produtoModel;
        }

        public object PostExclusao(int id)
        {
            var produtoModel = _context.ProdutoModel.Find(id);
            _context.ProdutoModel.Remove(produtoModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public object PutEdicao(int id, ProdutoModel produtoModel)
        {
            if (produtoModel.Id == 0)
                produtoModel.Id = id;
            try
            {
                _context.Update(produtoModel);
                _context.SaveChanges();
                return nameof(Index);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
