using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaItensRepository _vendaItensRepository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IVendaItensRepository vendaItensRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _vendaItensRepository = vendaItensRepository;
            _mapper = mapper;
        }

        public ICollection<VendaModel> GetAll()
        {
            return _vendaRepository.GetAll();
        }

        public VendaModel GetOne(Guid? id)
        {
            return _vendaRepository.GetOne(id);
        }

        public VendaModel GetEdicao(Guid? id)
        {
            return _vendaRepository.GetEdicao(id);
        }

        public object PutEdicao(Guid id, VendaModel venda)
        {
            venda.VendaId = id;
            _vendaRepository.PutEdicao(venda);
            return true;
        }

        public bool PostExclusao(Guid id)
        {
            var res = _vendaRepository.GetOne(id);
            if(res != null) { 
                _vendaRepository.PostExclusao(res);
                return true;
            }
            return false;
        }
    }
}
