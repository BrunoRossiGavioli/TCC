using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly TCCESTOQUEContext _context;

        public VendedorRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public ICollection<VendedorModel> GetCriacao()
        {
            return _context.VendedorModel.ToList();
        }

        public void PostCriacao(VendedorModel vendedorModel)
        {
            _context.Add(vendedorModel);
            _context.SaveChanges();
        }

        public VendedorModel GetOne(int? id)
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

        public void PutEdicao(VendedorModel vendedorModel)
        {
            _context.VendedorModel.Update(vendedorModel);
            _context.SaveChanges();
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
            IList<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, vendedorModel.Nome),
                new Claim(ClaimTypes.Email, vendedorModel.Email),
                new Claim(ClaimTypes.SerialNumber, Convert.ToString(vendedorModel.VendedorId))
            };

            var minhaIdentity = new ClaimsIdentity(Claims, "Vendedor");
            var vendPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
            return vendPrincipal;
        }

        public VendedorModel GetByCpf(string cpf)
        {
            return _context.VendedorModel.Where(a => a.Cpf == cpf).FirstOrDefault();
        }

        public VendedorModel GetByPhone(string telefone)
        {
            return _context.VendedorModel.Where(a => a.Telefone == telefone).FirstOrDefault();
        }

        public VendedorModel GetByEmail(string email)
        {
            return _context.VendedorModel.Where(a => a.Email == email).FirstOrDefault();
        }

        public VendedorModel GetSenha(string senha)
        {
            senha = SecurityService.Criptografar(senha);
            return _context.VendedorModel.Where(a => a.Senha == senha).FirstOrDefault();
        }
    }
}
