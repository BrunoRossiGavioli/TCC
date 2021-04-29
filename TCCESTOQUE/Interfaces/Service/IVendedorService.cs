using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService : IServiceBase<VendedorModel>
    {
        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel);
    }
}
