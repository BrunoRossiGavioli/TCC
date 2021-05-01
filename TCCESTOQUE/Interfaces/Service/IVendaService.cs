﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaService : IServiceBase<VendaModel>
    {
        public ValidationResult PostCricao(VendaViewModel venda);

        public VendaModel GetEdicao(int? id);

        public object PutEdicao(int id, VendaModel venda);
    }
}
