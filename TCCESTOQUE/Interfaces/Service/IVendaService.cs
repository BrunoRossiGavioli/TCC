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

<<<<<<< HEAD
        public object PutEdicao(Guid id, VendaModel venda);
=======
        public object PutEdicao(int id, VendaModel venda);

        public bool PostExclusao(int id);
>>>>>>> 2f52e926b313da0a5fe6427d67fd5779177e9a86
    }
}
