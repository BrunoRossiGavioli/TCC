using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendaItensRepository
    {
        public VendaItensModel GetOne(int? id);

        public void PostCriacao(VendaItensModel vendaItens);

        public VendaItensModel GetEdicao(int? id);

        public void PutEdicao(VendaItensModel vendaItens);

        public void PostExlusao(VendaItensModel vendaItens);
    }
}
