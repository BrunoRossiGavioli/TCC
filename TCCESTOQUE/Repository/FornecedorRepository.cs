using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Repository
{
    public class FornecedorRepository : BaseRepository<FornecedorModel>, IFornecedorRepository
    {
        public FornecedorRepository(TCCESTOQUEContext context) : base(context)
        {
            
        }

        public ICollection<FornecedorModel> GetAll()
        {
            return _context.FornecedorModel.ToList();
        }

        public override FornecedorModel GetOne(int? id)
        {
            var fornecedorModel = _context.FornecedorModel
                .Include(e => e.Endereco)
                .Include(p => p.Produtos)
                .FirstOrDefault(m => m.FornecedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetByCnpj(string cnpj)
        {
            return _context.FornecedorModel.Where(f => f.Cnpj == cnpj).FirstOrDefault();
        }

        public FornecedorModel GetByRazaoSocial(string razao)
        {
            return _context.FornecedorModel.Where(f => f.RazaoSocial == razao).FirstOrDefault();
        }

        public FornecedorModel GetByNomeFantsia(string nome)
        {
            return _context.FornecedorModel.Where(f => f.NomeFantasia == nome).FirstOrDefault();
        }

        public FornecedorModel GetByEmail(string email)
        {
            return _context.FornecedorModel.Where(f => f.Email == email).FirstOrDefault();
        }
    }
}
