using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaService
    {
        public ICollection<VendaModel> GetIndex();
        public VendaModel GetDetalhes(int? id);

        public object PostCricao(VendaViewModel venda);

        public object GetCricao(int id);

        public VendaModel GetEdicao(int? id);

        public object PutEdicao(int id, VendaModel venda);

        public VendaModel GetExclusao(int? id);

        public VendaModel PostExclusao(int id);

        public SelectList SelectListCliente(string dataValue, string textValue);
        public SelectList SelectListCliente(string dataValue, string textValue, object selectedValue);

        public SelectList SelectListVendedor(string dataValue, string textValue);
        public SelectList SelectListVendedor(string dataValue, string textValue, object selectedValue);

        public SelectList SelectListProduto(string dataValue, string textValue);
        public SelectList SelectListProduto(string dataValue, string textValue, object selectedValue);
    }
}
