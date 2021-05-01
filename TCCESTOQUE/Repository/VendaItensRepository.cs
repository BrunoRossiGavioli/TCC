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
    public class VendaItensRepository : IVendaItensRepository
    {
        private readonly TCCESTOQUEContext _context;

        public VendaItensRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }
        public VendaItensModel GetOne(int? id)
        {
            var vendaItensModel = _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefault(m => m.VendaItensId == id);

            return vendaItensModel;
        }

        public void PostCriacao(VendaItensModel vendaItens)
        {
            _context.Add(vendaItens);
            _context.SaveChanges();
        }

        public VendaItensModel GetEdicao(int? id)
        {
            return _context.VendaItensModel.Find(id);
        }

        public void PutEdicao(VendaItensModel vendaItens)
        {
            _context.Update(vendaItens);
            _context.SaveChanges();
        }

        public void PostExlusao(VendaItensModel vendaItens)
        {
            _context.VendaItensModel.Remove(vendaItens);
            _context.SaveChanges();
        }

    }
}
