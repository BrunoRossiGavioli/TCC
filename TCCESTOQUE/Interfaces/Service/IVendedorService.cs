using System.Security.Claims;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService
    {
        public VendedorModel GetDetalhes(int? id);

        public object GetCriacao();

        public bool PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(int? id);

        public bool PutEdicao(int id, VendedorModel vendedorModel);

        public VendedorModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel);
    }
}
