using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Service
{
    public class VendaItensService : IVendaItensService
    {
        private readonly IVendaItensRepository _vendaItensRepository;
        public VendaItensService(IVendaItensRepository vendaItensRepository)
        {
            _vendaItensRepository = vendaItensRepository;
        }

        public ICollection<VendaItensModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public VendaItensModel GetOne(int? id)
        {
            return _vendaItensRepository.GetOne(id);
        }

        public bool PostItem(VendaItensModel vendaItens)
        {
            _vendaItensRepository.PostCriacao(vendaItens);
            return true;
        }

        public bool PutEdicao(VendaItensModel vendaItens)
        {
            _vendaItensRepository.PutEdicao(vendaItens);
            return true;
        }

        public bool PostExclusao(int id)
        {
            var model = _vendaItensRepository.GetOne(id);
            if(model != null) { 
                _vendaItensRepository.PostExclusao(model);
                return true;
            }
            return false;
        }
    }
}
