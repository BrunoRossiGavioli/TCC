using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IEntradaService : IBaseService<EntradaModel>
    {
        public void PostEntrada(EntradaModel entrada);

        public string CancelarEntrada(EntradaModel entrada);
    }
}
