using FluentValidation.Results;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService : IBaseService<VendedorModel>
    {
        public ValidationResult PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(int? id);

        public ValidationResult PutEdicao(int id, VendedorModel vendedorModel);

        public bool PostExclusao(int id);

        public object PostLogin(VendedorModel vendedorModel);
    }
}
