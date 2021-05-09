using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface ICarrinhoService : IBaseService<CarrinhoModel>
    {
        public bool Finalizar(CarrinhoModel carrinho);
    }
}
