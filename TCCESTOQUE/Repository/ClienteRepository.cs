using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TCCESTOQUEContext _context;

        public ClienteRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public object GetIndex()
        {
            return _context.ClienteModel.ToList();
        }

        public ClienteModel GetDetalhes(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.ClienteId == id);
        }

        public object PostCriacao(ClienteModel cliente)
        {
            try
            {
                _context.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            { 
                return false;
            }

        }

        public ClienteModel GetEdicao(int? id)
        {
            return _context.ClienteModel.Find(id);
        }

        public object PutEdicao(int id, ClienteModel cliente)
        {
            try
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public ClienteModel GetExclusao(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.ClienteId == id);
        }

        public object PostExclusao(int id)
        {
            try
            {
                var clienteModel = _context.ClienteModel.Find(id);
                _context.ClienteModel.Remove(clienteModel);
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
