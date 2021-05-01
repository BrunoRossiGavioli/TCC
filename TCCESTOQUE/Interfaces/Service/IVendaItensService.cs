using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaItensService : IServiceBase<VendaItensModel>
    {
        public bool PostCriacao(VendaItensModel vendaItens);

        public bool PutEdicao(VendaItensModel vendaItens);
    }
}
