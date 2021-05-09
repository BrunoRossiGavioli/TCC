using AutoMapper;
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
    public class ClienteRepository : BaseRepository<ClienteModel>,  IClienteRepository
    {
        public ClienteRepository(TCCESTOQUEContext context) :base(context)
        {
            
        }

        public ICollection<ClienteModel> GetAll(Guid vendedorId)
        {
            return _context.ClienteModel.Where(v => v.VendedorId == vendedorId).ToList();
        }

        public override ClienteModel GetOne(Guid? id)
        {
            return _context.ClienteModel.Include(v => v.Venda).Include(v => v.Vendedor).FirstOrDefault(m => m.ClienteId == id);
        }
    }
}
