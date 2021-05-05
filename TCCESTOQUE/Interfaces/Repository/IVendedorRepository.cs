using System.Collections.Generic;
using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendedorRepository : IBaseRepository<VendedorModel>
    {
        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel);

        public VendedorModel GetByCpf(string cpf);

        public VendedorModel GetByTelefone(string telefone);
        
        public VendedorModel GetByEmail(string email);

        public VendedorModel GetBySenha(string senha);

    }
}
