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
    public class VendedorRepository : BaseRepository<VendedorModel>, IVendedorRepository
    {
        public VendedorRepository(TCCESTOQUEContext context) : base(context)
        {

        }

        public ICollection<VendedorModel> GetAll()
        {
            return _context.VendedorModel.ToList();
        }

        public override VendedorModel GetOne(int? id)
        {
            var vendedorModel = _context.VendedorModel
                .FirstOrDefault(m => m.VendedorId == id);

            if (vendedorModel == null)
                return null;

            return vendedorModel;
        }

        public ClaimsPrincipal PostLogin(VendedorModel vendedor)
        {
            IList<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, vendedor.Nome),
                new Claim(ClaimTypes.Email, vendedor.Email),
                new Claim(ClaimTypes.SerialNumber, Convert.ToString(vendedor.VendedorId))
            };

            var minhaIdentity = new ClaimsIdentity(Claims, "Vendedor");
            return new ClaimsPrincipal(new[] { minhaIdentity });
        }

        public VendedorModel GetByCpf(string cpf)
        {
            return _context.VendedorModel.Where(a => a.Cpf == cpf).FirstOrDefault();
        }

        public VendedorModel GetByTelefone(string telefone)
        {
            return _context.VendedorModel.Where(a => a.Telefone == telefone).FirstOrDefault();
        }

        public VendedorModel GetByEmail(string email)
        {
            return _context.VendedorModel.Where(a => a.Email == email).FirstOrDefault();
        }

        public VendedorModel GetBySenha(string senha)
        {
            senha = SecurityService.Criptografar(senha);
            return _context.VendedorModel.Where(a => a.Senha == senha).FirstOrDefault();
        }
    }
}
