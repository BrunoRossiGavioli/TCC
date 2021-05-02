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
    public class VendaRepository : BaseRepository<VendaModel>,IVendaRepository
    {

        public VendaRepository(TCCESTOQUEContext context) : base(context)
        {

        }

        public override VendaModel GetOne(int? id)
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
    }
}
