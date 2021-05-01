using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IVendaRepository
    {
        public ICollection<VendaModel> GetAll();

        public VendaModel GetOne(int? id);

        public void PostCricao(VendaModel venda);

        public VendaModel GetEdicao(int? id);

        public void PutEdicao(VendaModel venda);

        public void PostExclusao(VendaModel venda);
    }
}
