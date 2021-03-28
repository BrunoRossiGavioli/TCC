using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService
    {
        public VendedorModel GetDetalhes(int? id);

        public IActionResult GetCriacao();

        public VendedorModel GetEdicao(int? id);

        public VendedorModel GetExclusao(int? id);


        public object PostCriacao(VendedorModel vendedorModel);

        public object PostEdicao(int id, VendedorModel vendedorModel);

        public object PostExclusao(int id);
    }
}
