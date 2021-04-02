using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService
    {
        public VendedorModel GetDetalhes(int? id);

        public IActionResult GetCriacao();

        public object PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(int? id);

        public object PutEdicao(int id, VendedorModel vendedorModel);

        public VendedorModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public void GetLogin();

        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel);
    }
}
