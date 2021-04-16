﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public ICollection<VendaModel> GetIndex()
        {
            return _vendaRepository.GetIndex();
        }

        public VendaModel GetDetalhes(int? id)
        {
            return _vendaRepository.GetDetalhes(id);
        }

        public object GetCricao(int id)
        {
            return _vendaRepository.GetCricao(id);
        }

        public object PostCricao(VendaViewModel venda)
        {
            return _vendaRepository.PostCricao(venda);
        }

        public VendaModel GetEdicao(int? id)
        {
            return _vendaRepository.GetEdicao(id);
        }

        public object PutEdicao(int id, VendaModel venda)
        {
            return _vendaRepository.PutEdicao(id, venda);
        }

        public VendaModel GetExclusao(int? id)
        {
            return _vendaRepository.GetExclusao(id);
        }

        public VendaModel PostExclusao(int id)
        {
            return _vendaRepository.PostExclusao(id);
        }

        public SelectList SelectListCliente(string dataValue, string textValue)
        {
            return _vendaRepository.SelectListCliente(dataValue, textValue);
        }

        public SelectList SelectListCliente(string dataValue, string textValue, object selectedValue)
        {
            return _vendaRepository.SelectListCliente(dataValue, textValue, selectedValue);
        }

        public SelectList SelectListVendedor(string dataValue, string textValue)
        {
            return _vendaRepository.SelectListVendedor(dataValue, textValue);
        }

        public SelectList SelectListVendedor(string dataValue, string textValue, object selectedValue)
        {
            return _vendaRepository.SelectListVendedor(dataValue, textValue, selectedValue);
        }

        public SelectList SelectListProduto(string dataValue, string textValue)
        {
            return _vendaRepository.SelectListProduto(dataValue, textValue);
        }

        public SelectList SelectListProduto(string dataValue, string textValue, object selectedValue)
        {
            return _vendaRepository.SelectListProduto(dataValue, textValue, selectedValue);
        }
    }
}
