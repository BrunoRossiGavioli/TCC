using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;

namespace TCCESTOQUE.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly TCCESTOQUEContext _context;

        public VendedorRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public IActionResult GetCriacao()
        {
            throw new NotImplementedException();
        }

        public VendedorModel GetDetalhes(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var vendedorModel = _context.VendedorModel
                .FirstOrDefault(m => m.Id == id);
            if (vendedorModel == null)
            {
                return null;
            }

            return vendedorModel;
        }

        public VendedorModel GetEdicao(int? id)
        {
            var vendedorModel = _context.VendedorModel.Find(id);
            var validacao = new VendedorValidador().Validate(vendedorModel);
            if (!validacao.IsValid) 
            {
                var erros = validacao.Errors.Select(e => e.ErrorMessage).ToList();
                return null;
            }
            return vendedorModel;

        }

        public VendedorModel GetExclusao(int? id)
        {
            var vendedorModel = _context.VendedorModel
                .FirstOrDefault(m => m.Id == id);

            if (id != vendedorModel.Id || id == null)
                return null;
            var validacao = new VendedorValidador().Validate(vendedorModel);
            if (!validacao.IsValid)
                return null;

                return vendedorModel;
        }

        public object PostCriacao(VendedorModel vendedorModel)
        {
            //PRECISA DE VALIDAÇÃO COM FLUENT VALIDATION!!! @KAYKY   
            var validacao = new VendedorValidador().Validate(vendedorModel);
            if (validacao.IsValid) 
            { 
                _context.Add(vendedorModel);
                _context.SaveChanges();
            }
            return vendedorModel;
        }

        public object PostEdicao(int id, VendedorModel vendedorModel)
        {
            //PERGUNTAR AO NIZZOLA SE TEM COMO MELHORAR ESSE CODIGO
            vendedorModel.Id = id;
            var validacao = new VendedorValidador().Validate(vendedorModel);
            if (validacao.IsValid)
            {
                try
                {
                    _context.Update(vendedorModel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }
            }

            return vendedorModel;
        }

        public object PostExclusao(int id)
        {
            var vendedorModel = _context.VendedorModel.Find(id);
            if(id == vendedorModel.Id) { 
            _context.VendedorModel.Remove(vendedorModel);
            _context.SaveChanges();
            }
            return null;
            
        }
    }
}
