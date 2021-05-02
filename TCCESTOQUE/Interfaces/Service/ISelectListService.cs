using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface ISelectListService
    {
        public SelectList SelectListCliente(string dataValue, string textValue);
        public SelectList SelectListCliente(string dataValue, string textValue, object selectedValue);

        public SelectList SelectListVendedor(string dataValue, string textValue);
        public SelectList SelectListVendedor(string dataValue, string textValue, object selectedValue);

        public SelectList SelectListProduto(string dataValue, string textValue);
        public SelectList SelectListProduto(string dataValue, string textValue, object selectedValue);

        public SelectList SelectListFornecedor(string dataValue, string textValue);
        public SelectList SelectListFornecedor(string dataValue, string textValue, object selectedValue);
        
        public SelectList SelectListVenda(string dataValue, string textValue);
        public SelectList SelectListVenda(string dataValue, string textValue, object selectedValue);
    }
}
