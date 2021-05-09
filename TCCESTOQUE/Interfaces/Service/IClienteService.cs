using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.Models.Enum;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IClienteService : IBaseService<ClienteModel>
    {

        public ValidationResult PostCriacao(ClienteViewModel cliente);

        public ClienteViewModel GetEdicao(Guid? id);

        public ValidationResult PutEdicao(ClienteViewModel cliente);

        public bool PostExclusao(Guid id);
    }
}
