﻿using System;
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

        public VendaItensModel GetDetalhes(int? id)
        {
            return _vendaItensRepository.GetDetalhes(id);
        }

        public object PostCriacao(VendaItensModel vendaItens, int id)
        {
            if (vendaItens.VendaId == id)
                return _vendaItensRepository.PostCriacao(vendaItens, id);

            return false;
        }

        public VendaItensModel GetEdicao(int? id)
        {
            return _vendaItensRepository.GetEdicao(id);
        }

        public object PutEdicao(int? id, VendaItensModel vendaItens)
        {
            return _vendaItensRepository.PutEdicao(id, vendaItens);
        }

        public VendaItensModel GetExclusao(int? id)
        {
            return _vendaItensRepository.GetExclusao(id);
        }

        public object PostExlusao(int id)
        {
            return _vendaItensRepository.PostExlusao(id);
        }
    }
}