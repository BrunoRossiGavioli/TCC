using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaService : IBaseService<VendaModel>
    {
        public ValidationResult PostCricao(VendaViewModel venda);

        public VendaModel GetEdicao(Guid? id);

        public object PutEdicao(Guid id, VendaModel venda);
    }
}
