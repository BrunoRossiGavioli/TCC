using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class ProdutoRepository : BaseRepository<ProdutoModel>,IProdutoRepository
    {
        public ProdutoRepository(TCCESTOQUEContext context) :base(context)
        {
            
        }

        public ICollection<ProdutoModel> GetAll(Guid vendedorId)
        {
            return _context.ProdutoModel
                .Include(p => p.Fornecedor)
                .Where(v => v.VendedorId == vendedorId)
                .ToList();
        }

        public override ProdutoModel GetOne(Guid? id)
        {
            var produtoModel = _context.ProdutoModel
                .FirstOrDefault(m => m.ProdutoId == id);

            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public override ProdutoModel GetEdicao(Guid? id)
        {
            var produtoModel = _context.ProdutoModel.Find(id);
            if (produtoModel == null)
                return null;

            return produtoModel;
        }
    }
}
