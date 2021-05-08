using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IMovimentacaoService
    {
        public string BaixarEstoque(Guid produtoId, double quantidade, bool checar = true);

        public void SubirEstoque(Guid produtoId, double quantidade);

        public string ChecarEstoque(Guid produtoId, double quantidade);
    }
}
