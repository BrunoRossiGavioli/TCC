using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly TCCESTOQUEContext _context;

        public FornecedorRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public object GetIndex()
        {
            return _context.FornecedorModel.ToList();
        }

        public object GetCriacao()
        {
            return null;
        }

        public FornecedorModel GetDetalhes(int? id)
        {
            if (id == null)
                return null;

            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.ForncedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetEdicao(int? id)
        {
            if (id == null)
                return null;

            var fornecedorModel = _context.FornecedorModel.Find(id);
            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetExclusao(int? id)
        {
            if (id == null)
                return null;

            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.ForncedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public object PostCriacao(FornecedorModel fornecedorModel)
        {
            _context.Add(fornecedorModel);
            _context.SaveChanges();
            return fornecedorModel;
        }

        public object PostExclusao(int id)
        {
            var fornecedorModel = _context.FornecedorModel.Find(id);
            _context.FornecedorModel.Remove(fornecedorModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public object PutEdicao(int id, FornecedorModel fornecedorModel)
        {
            if (fornecedorModel.ForncedorId == 0)
                fornecedorModel.ForncedorId = id;
            try
            {
                _context.Update(fornecedorModel);
                _context.SaveChanges();
                return nameof(Index);
            }
            catch (Exception) 
            { 
                throw;
            }
        }
    }
}
