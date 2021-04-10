using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.ValidadorVendedor;

namespace TCCESTOQUE.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly TCCESTOQUEContext _context;

        public VendedorRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public object GetCriacao()
        {
            return _context.VendedorModel.ToList();
        }

        public bool PostCriacao(VendedorModel vendedorModel)
        {
            _context.Add(vendedorModel);
            _context.SaveChanges();
            return true;
        }

        public VendedorModel GetDetalhes(int? id)
        {
            var vendedorModel = _context.VendedorModel
                .FirstOrDefault(m => m.VendedorId == id);

            if (vendedorModel == null)
                return null;

            return vendedorModel;
        }

        public VendedorModel GetEdicao(int? id)
        {
            return _context.VendedorModel.Find(id);
        }

        public bool PutEdicao(int id, VendedorModel vendedorModel)
        {
            try
            {
                _context.Update(vendedorModel);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public VendedorModel GetExclusao(int? id)
        {
            var vendedor = _context.VendedorModel
                .FirstOrDefault(m => m.VendedorId == id);

            if (vendedor == null)
                return null;

            return vendedor;
        }

        public object PostExclusao(int id)
        {
            var vendedorModel = _context.VendedorModel.Find(id);
            if (vendedorModel.VendedorId == id)
            {
                _context.VendedorModel.Remove(vendedorModel);
                _context.SaveChanges();
            }
            return null;

        }

        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel)
        {
            var vendedor = _context.VendedorModel.Where(a => a.Email == vendedorModel.Email).FirstOrDefault();
            if (vendedor == null)
                return null;
            if (vendedor.Senha != SecurityService.Criptografar(vendedorModel.Senha))
                return null;

            var claim1 = new Claim(ClaimTypes.Name, vendedor.Nome);
            var claim2 = new Claim(ClaimTypes.Email, vendedor.Email);

            IList<Claim> Claims = new List<Claim>()
            {
                claim1,
                claim2
            };

            var minhaIdentity = new ClaimsIdentity(Claims, "Vendedor");
            var vendPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });

            return vendPrincipal;
        }
    }
}
