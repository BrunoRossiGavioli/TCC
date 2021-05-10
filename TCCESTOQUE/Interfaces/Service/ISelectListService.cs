using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface ISelectListService
    {
        public SelectList SelectListCliente(string dataValue, string textValue, Guid vendedorId);
        public SelectList SelectListCliente(string dataValue, string textValue, object selectedValue, Guid vendedorId);

        public SelectList SelectListProduto(string dataValue, string textValue, Guid vendedorId);
        public SelectList SelectListProduto(string dataValue, string textValue, object selectedValue, Guid vendedorId);

        public SelectList SelectListFornecedor(string dataValue, string textValue, Guid vendedorId);
        public SelectList SelectListFornecedor(string dataValue, string textValue, object selectedValue, Guid vendedorId);
        
        public SelectList SelectListVenda(string dataValue, string textValue, Guid vendedorId);
        public SelectList SelectListVenda(string dataValue, string textValue, object selectedValue, Guid vendedorId);
    }
}
