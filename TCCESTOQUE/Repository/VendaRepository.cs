using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly TCCESTOQUEContext _context;

        public VendaRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public VendaModel GetOne(int? id)
        {
            var vendaModel = _context.VendaModel
                .Include(v => v.Itens)
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .FirstOrDefault(m => m.VendaId == id);

            vendaModel.Itens = _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Produto.Fornecedor)
                .ToList();

            return vendaModel;
        }

        public ICollection<VendaModel> GetAll()
        {
            return _context.VendaModel.Include(v => v.Cliente).Include(v => v.Vendedor).ToList();
        }

        public void PostCricao(VendaModel venda)
        {
            _context.Add(venda);
            _context.SaveChanges();
        }

        public VendaModel GetEdicao(int? id)
        {
            return _context.VendaModel.Find(id);
        }
        public void PutEdicao(VendaModel venda)
        {
            _context.Update(venda);
            _context.SaveChangesAsync();
        }

        public void PostExclusao(VendaModel venda)
        {
            _context.VendaModel.Remove(venda);
            _context.SaveChanges();
        }
    }
}
