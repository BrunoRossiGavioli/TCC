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

        public object PostCricao(VendaViewModel vendaVM)
        {
            var vendaModel = _mapper.Map<VendaModel>(vendaVM);
            _vendaRepository.PostCricao(vendaModel);
            
            var itens = _mapper.Map<VendaItensModel>(vendaVM);
            itens.VendaId = vendaModel.VendaId;
            _vendaItensRepository.PostCriacao(itens);
            return true;
        }

        public VendaModel GetEdicao(int? id)
        {
            return _vendaRepository.GetEdicao(id);
        }

        public object PutEdicao(int id, VendaModel venda)
        {
            venda.VendaId = id;
            _vendaRepository.PutEdicao(venda);
            return true;
        }

        public VendaModel GetExclusao(int? id)
        {
            return _vendaRepository.GetExclusao(id);
        }

        public VendaModel PostExclusao(int id)
        {
            return _vendaRepository.PostExclusao(id);
        }
    }
}
