using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        public VendaItensModel GetDetalhes(int? id)
        {
            var vendaItensModel = _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefault(m => m.VendaItensId == id);

            return vendaItensModel;
        }

        public object PostCriacao(VendaItensModel vendaItens, int id)
        {
            try
            {
                _context.Add(vendaItens);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public VendaItensModel GetEdicao(int? id)
        {
            return _context.VendaItensModel.Find(id);
        }

        public object PutEdicao(int? id, VendaItensModel vendaItens)
        {
            try
            {
                _context.Update(vendaItens);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public VendaItensModel GetExclusao(int? id)
        {
            var vendaItens = _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefault(m => m.VendaItensId == id);

            return vendaItens;
        }

        public object PostExlusao(int id)
        {
            var vendaItens = _context.VendaItensModel.Find(id);
            try
            {
                _context.VendaItensModel.Remove(vendaItens);
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
