using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

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
            return vendedorModel;
        }

        public VendedorModel GetExclusao(int? id)
        {
            var vendedorModel = _context.VendedorModel
                .FirstOrDefault(m => m.Id == id);
            //if (vendedorModel == null)
            //    return null();


            return vendedorModel;
        }

        public object PostCriacao(VendedorModel vendedorModel)
        {
                 //PRECISA DE VALIDAÇÃO COM FLUENT VALIDATION!!! @KAYKY
                _context.Add(vendedorModel);
                _context.SaveChangesAsync();
                return ("Index", "Home");
        }

        public object PostEdicao(int id, VendedorModel vendedorModel)
        {
            //PRECISA DE FLUENT VALIDATION!!! @KAYKY
            //if (ModelState.IsValid){
                try
                {
                    _context.Update(vendedorModel);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return null;
                }
                return nameof(Index);
            //}

            //return vendedorModel;
        }

        public object PostExclusao(int id)
        {
            var vendedorModel = _context.VendedorModel.Find(id);
            _context.VendedorModel.Remove(vendedorModel);
            _context.SaveChanges();
            return nameof(Index);
        }
    }
}
