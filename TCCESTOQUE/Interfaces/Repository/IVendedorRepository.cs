using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendedorRepository
    {
        public VendedorModel GetDetalhes(int? id);
        public object GetCriacao();
        public bool PostCriacao(VendedorModel vendedorModel);
        public VendedorModel GetEdicao(int? id);
        public bool PutEdicao(int id, VendedorModel vendedorModel);
        public VendedorModel GetExclusao(int? id);
        public object PostExclusao(int id);
        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel);
        public VendedorModel GetByCpf(string cpf);
        public VendedorModel GetByPhone(string telefone);
        public VendedorModel GetByEmail(string email);
        public VendedorModel GetSenha(string senha);

    }
}
