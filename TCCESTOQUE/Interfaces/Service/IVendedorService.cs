using FluentValidation.Results;
using System.Collections.Generic;
using System.Security.Claims;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService
    {
        public VendedorModel GetOne(int? id);

        public ICollection<VendedorModel> GetCriacao();

        public ValidationResult PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(int? id);

        public ValidationResult PutEdicao(int id, VendedorModel vendedorModel);

        public object PostExclusao(int id);

        public object PostLogin(VendedorModel vendedorModel);
    }
}
