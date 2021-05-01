using System.Collections.Generic;
using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendedorRepository
    {
        public VendedorModel GetOne(int? id);

        public ICollection<VendedorModel> GetCriacao();

        public void PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(int? id);

        public void PutEdicao(VendedorModel vendedorModel);

        public void PostExclusao(VendedorModel model);

        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel);

        public VendedorModel GetByCpf(string cpf);
        public VendedorModel GetByPhone(string telefone);
        public VendedorModel GetByEmail(string email);

        public VendedorModel GetSenha(string senha);

    }
}
