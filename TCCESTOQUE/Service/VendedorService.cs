using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;

namespace TCCESTOQUE.Service
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        public VendedorService(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
        }
        public IActionResult GetCriacao()
        {
            throw new NotImplementedException();
        }

        public VendedorModel GetDetalhes(int? id)
        {
            return _vendedorRepository.GetDetalhes(id);
        }

        public VendedorModel GetEdicao(int? id)
        {
            return _vendedorRepository.GetEdicao(id);
        }

        public VendedorModel GetExclusao(int? id)
        {
            return _vendedorRepository.GetExclusao(id);
        }

        public object PostCriacao(VendedorModel vendedorModel)
        {
            return _vendedorRepository.PostCriacao(vendedorModel);
        }

        public object PostEdicao(int id, VendedorModel vendedorModel)
        {
            return _vendedorRepository.PostEdicao(id, vendedorModel);
        }

        public object PostExclusao(int id)
        {
            return _vendedorRepository.PostExclusao(id);
        }
    }
}
