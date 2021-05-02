using AutoMapper;
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

        public ICollection<ClienteModel> GetAll()
        {
            return _context.ClienteModel.ToList();
        }

        public override ClienteModel GetOne(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.ClienteId == id);
        }
    }
}
