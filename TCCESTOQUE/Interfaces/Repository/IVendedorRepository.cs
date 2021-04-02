using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

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

        public void GetLogin();

        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel);
    }
}
