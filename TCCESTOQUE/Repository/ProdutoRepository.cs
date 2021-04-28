using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProdutoRepository(TCCESTOQUEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public object GetIndex()
        {
            var tCCESTOQUEContext = _context.ProdutoModel.Include(p => p.Fornecedor);
            return tCCESTOQUEContext.ToList();
        }

        public object GetCriacao()
        {
            var res = new SelectList(_context.FornecedorModel, "FornecedorId", "NomeFantasia");
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
            var produtoModel = _mapper.Map<ProdutoModel>(_context.ProdutoModel.Find(id));
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
           // var mapeamento = _mapper.Map<ProdutoModel>(produtoModel);
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

        public VendedorModel GetByIdVendedor(int id)
        {
            return _context.VendedorModel.Where(a => a.VendedorId == id).FirstOrDefault();
        }
    }
}
