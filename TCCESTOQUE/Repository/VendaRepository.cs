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
        private readonly IMapper _mapper;

        public VendaRepository(TCCESTOQUEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VendaModel GetDetalhes(int? id)
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

        public ICollection<VendaModel> GetIndex()
        {
            return _context.VendaModel.Include(v => v.Cliente).Include(v => v.Vendedor).ToList();
        }

        public object GetCricao(int id)
        {
            throw new NotImplementedException();
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

        public VendaModel GetExclusao(int? id)
        {
            var vendaModel = _context.VendaModel
            .Include(v => v.Cliente)
            .Include(v => v.Vendedor)
            .FirstOrDefault(m => m.VendaId == id);
            return vendaModel;
        }

        public VendaModel PostExclusao(int id)
        {
            var vendaModel = _context.VendaModel.Find(id);
            _context.VendaModel.Remove(vendaModel);
            _context.SaveChanges();
            return vendaModel;
        }
    }
}
