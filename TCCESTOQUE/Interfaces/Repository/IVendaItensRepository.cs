using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendaItensRepository
    {
        public VendaItensModel GetDetalhes(int? id);

        public void PostCriacao(VendaItensModel vendaItens);

        public VendaItensModel GetEdicao(int? id);

        public void PutEdicao(VendaItensModel vendaItens);

        public VendaItensModel GetExclusao(int? id);

        public object PostExlusao(int id);
    }
}
