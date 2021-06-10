using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.POCO;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface ISenhaRepository : IBaseRepository<AlterarSenhaModel>
    {
        public AlterarSenhaModel GetOneByCodigo(AlterarSenha model);
    }
}
