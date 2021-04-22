using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaItensService
    {
        public VendaItensModel GetDetalhes(int? id);

        public object PostCriacao(VendaItensModel vendaItens, int id);

        public VendaItensModel GetEdicao(int? id);

        public object PutEdicao(int? id, VendaItensModel vendaItens);

        public VendaItensModel GetExclusao(int? id);

        public object PostExlusao(int id);
    }
}
