using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaItensService : IBaseService<VendaItensModel>
    {
        public bool PostItem(VendaItensModel vendaItens);

        public bool PutEdicao(VendaItensModel vendaItens);

        public bool PostExclusao(int id);

        ICollection<VendaItensModel> GetByVendaId(int vendaId);
    }
}
