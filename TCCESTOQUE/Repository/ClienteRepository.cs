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
    public class ClienteRepository : IClienteRepository
    {
        private readonly TCCESTOQUEContext _context;


        public ClienteRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public ICollection<ClienteModel> GetIndex()
        {
            return _context.ClienteModel.ToList();
        }

        public ClienteModel GetOne(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.ClienteId == id);
        }

        public void PostCriacao(ClienteModel cliente)
        {
                _context.Add(cliente);
                _context.SaveChanges();
        }

        public ClienteModel GetEdicao(int? id)
        {
            return _context.ClienteModel.Find(id);
        }

        public void PutEdicao(ClienteModel cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void PostExclusao(ClienteModel cliente)
        {
            _context.ClienteModel.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
