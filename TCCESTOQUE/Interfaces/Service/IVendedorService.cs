using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService : IBaseService<VendedorModel>
    {
        public ValidationResult PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(Guid? id);

        public ValidationResult PutEdicao(Guid id, VendedorModel vendedorModel);

        public bool PostExclusao(Guid id);

        public object PostLogin(VendedorModel vendedorModel);
    }
}
