using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;

namespace TCCESTOQUE.Service
{
    public class SelectListService : ISelectListService
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IVendedorRepository _vendedorRepo;
        private readonly IProdutoRepository _produtoRepo;
        private readonly IFornecedorRepository _fornecedorRepo;
        private readonly IVendaRepository _vendaRepo;
        public SelectListService(IVendaRepository vendaRepo,IProdutoRepository produtoRepo,IClienteRepository clienteRepo,
                                 IVendedorRepository vendedorRepo,IFornecedorRepository fornecedorRepo)
            {
                _produtoRepo = produtoRepo;
                _vendaRepo = vendaRepo;
                _clienteRepo = clienteRepo;
                _vendedorRepo = vendedorRepo;
                _fornecedorRepo = fornecedorRepo;
            }

        #region ListCliente
        public SelectList SelectListCliente(string dataValue, string textValue)
        {
            return new SelectList(_clienteRepo.GetContext(), dataValue, textValue);
        }

        public SelectList SelectListCliente(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_clienteRepo.GetContext(), dataValue, textValue, selectedValueId);
        }
        #endregion

        #region ListVendedor
        public SelectList SelectListVendedor(string dataValue, string textValue)
        {
            return new SelectList(_vendedorRepo.GetContext(), dataValue, textValue);
        }

        public SelectList SelectListVendedor(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_vendedorRepo.GetContext(), dataValue, textValue, selectedValueId);
        }
        #endregion

        #region ListProduto
        public SelectList SelectListProduto(string dataValue, string textValue)
        {
            return new SelectList(_produtoRepo.GetContext(), dataValue, textValue);
        }

        public SelectList SelectListProduto(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_produtoRepo.GetContext(), dataValue, textValue, selectedValueId);
        }
        #endregion

        #region ListFornecedor
        public SelectList SelectListFornecedor(string dataValue, string textValue)
        {
            return new SelectList(_fornecedorRepo.GetContext(), dataValue, textValue);
        }

        public SelectList SelectListFornecedor(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_fornecedorRepo.GetContext(), dataValue, textValue, selectedValueId); 
        }
        #endregion

        #region ListVenda
        public SelectList SelectListVenda(string dataValue, string textValue)
        {
            return new SelectList(_vendaRepo.GetContext(), dataValue, textValue);
        }

        public SelectList SelectListVenda(string dataValue, string textValue, object selectedValueId)
        {
            return new SelectList(_vendaRepo.GetContext(), dataValue, textValue, selectedValueId);
        }
        #endregion
    }
}
