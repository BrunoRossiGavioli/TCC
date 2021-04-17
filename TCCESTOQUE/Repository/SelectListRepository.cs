using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;

namespace TCCESTOQUE.Repository
{
    public class SelectListRepository : ISelectListRepository
    {
        private readonly TCCESTOQUEContext _context;

        public SelectListRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        #region ListCliente
        public SelectList SelectListCliente(string dataValue, string textValue)
        {
            return new SelectList(_context.ClienteModel, dataValue, textValue);
        }

        public SelectList SelectListCliente(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_context.ClienteModel, dataValue, textValue, selectedValueId);
        }
        #endregion

        #region ListVendedor
        public SelectList SelectListVendedor(string dataValue, string textValue)
        {
            return new SelectList(_context.VendedorModel, dataValue, textValue);
        }

        public SelectList SelectListVendedor(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_context.VendedorModel, dataValue, textValue, selectedValueId);
        }
        #endregion

        #region ListProduto
        public SelectList SelectListProduto(string dataValue, string textValue)
        {
            return new SelectList(_context.ProdutoModel, dataValue, textValue);
        }

        public SelectList SelectListProduto(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_context.ProdutoModel, dataValue, textValue, selectedValueId);
        }
        #endregion

        #region ListFornecedor
        public SelectList SelectListFornecedor(string dataValue, string textValue)
        {
            return new SelectList(_context.FornecedorModel, dataValue, textValue);
        }

        public SelectList SelectListFornecedor(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_context.FornecedorModel, dataValue, textValue, selectedValueId); 
        }
        #endregion

        #region ListVenda
        public SelectList SelectListVenda(string dataValue, string textValue)
        {
            return new SelectList(_context.VendaModel, dataValue, textValue);
        }

        public SelectList SelectListVenda(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_context.VendaModel, dataValue, textValue, selectedValueId);
        }
        #endregion
    }
}
