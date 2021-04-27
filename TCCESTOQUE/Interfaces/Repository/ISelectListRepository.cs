using Microsoft.AspNetCore.Mvc.Rendering;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface ISelectListRepository
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
