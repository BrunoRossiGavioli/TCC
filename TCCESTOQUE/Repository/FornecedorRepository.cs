﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class FornecedorRepository : BaseRepository<FornecedorModel>, IFornecedorRepository
    {
        public FornecedorRepository(TCCESTOQUEContext context) : base(context)
        {
            
        }

        public ICollection<FornecedorModel> GetAll(Guid vendedorId)
        {
            return _context.FornecedorModel.Where(v => v.VendedorId == vendedorId && !v.Desativado).ToList();
        }

        public override FornecedorModel GetOne(Guid? id)
        {
            var fornecedorModel = _context.FornecedorModel
                .Include(e => e.Endereco)
                .Include(p => p.Entradas)
                .FirstOrDefault(m => m.FornecedorId == id && !m.Desativado);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetByCnpj(string cnpj, Guid vendedorId)
        {
            return _context.FornecedorModel.Where(f => f.Cnpj == cnpj && f.VendedorId == vendedorId && !f.Desativado).FirstOrDefault();
        }

        public FornecedorModel GetByRazaoSocial(string razao, Guid vendedorId)
        {
            return _context.FornecedorModel.Where(f => f.RazaoSocial == razao && f.VendedorId == vendedorId && !f.Desativado).FirstOrDefault();
        }

        public FornecedorModel GetByNomeFantsia(string nome, Guid vendedorId)
        {
            return _context.FornecedorModel.Where(f => f.NomeFantasia == nome && f.VendedorId == vendedorId && !f.Desativado).FirstOrDefault();
        }

        public FornecedorModel GetByEmail(string email, Guid vendedorId)
        {
            return _context.FornecedorModel.Where(f => f.Email == email && f.VendedorId == vendedorId && !f.Desativado).FirstOrDefault();
        }
    }
}
