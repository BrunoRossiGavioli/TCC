using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface ICarrinhoService : IBaseService<CarrinhoModel>
    {
        public bool Finalizar(CarrinhoModel carrinho);
    }
}
