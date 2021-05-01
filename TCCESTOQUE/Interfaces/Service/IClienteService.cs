using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IClienteService : IServiceBase<ClienteModel>
    {

        public ValidationResult PostCriacao(ClienteViewModel cliente);

        public ClienteViewModel GetEdicao(int? id);

        public ValidationResult PutEdicao(ClienteViewModel cliente);
    }
}
