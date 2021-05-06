﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class ProdutoRepository : BaseRepository<ProdutoModel>, IProdutoRepository
    {
        public ProdutoRepository(TCCESTOQUEContext context) : base(context)
        {

        }

        public ICollection<ProdutoModel> GetAll()
        {
            var tCCESTOQUEContext = _context.ProdutoModel.Include(p => p.Fornecedor);
            return tCCESTOQUEContext.ToList();
        }

        public override ProdutoModel GetOne(int? id)
        {
            var produtoModel = _context.ProdutoModel
                .FirstOrDefault(m => m.ProdutoId == id);

            if (produtoModel == null)
                return null;

            return produtoModel;
        }

        public override ProdutoModel GetEdicao(int? id)
        {
            var produtoModel = _context.ProdutoModel.Find(id);
            if (produtoModel == null)
                return null;

            return produtoModel;
        }
    }
}
