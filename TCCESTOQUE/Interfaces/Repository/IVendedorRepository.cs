using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendedorRepository
    {
        public VendedorModel GetDetalhes(int? id);
        public object GetCriacao();
        public bool PostCriacao(VendedorModel vendedorModel);
        public VendedorEditViewModel GetEdicao(int? id);
        public bool PutEdicao(int id, VendedorEditViewModel vendedorModel);
        public VendedorModel GetExclusao(int? id);
        public object PostExclusao(int id);
        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel);
        public VendedorModel GetByCpf(string cpf);
        public VendedorModel GetByPhone(string telefone);
        public VendedorModel GetByEmail(string email);
        public VendedorModel GetSenha(string senha);

    }
}
