using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Service
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepo;
        private readonly IVendaRepository _vendaRepo;
        private readonly IVendaItensRepository _vendaItensRepo;

        public CarrinhoService(ICarrinhoRepository carrinhoRepo, IVendaRepository vendaRepo, IVendaItensRepository vendaItensRepo)
        {
            _carrinhoRepo = carrinhoRepo;
            _vendaRepo = vendaRepo;
            _vendaItensRepo = vendaItensRepo;
        }

        public ICollection<CarrinhoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Finalizar(CarrinhoModel carrinho)
        {
            var car = _carrinhoRepo.GetOneByVendedorId(carrinho.VendedorId);
            if(car.Itens.Count > 0) { 
                var venda = new VendaModel() { ClienteId = carrinho.ClienteId, DataVenda = DateTime.Now, VendedorId = car.VendedorId};
                _vendaRepo.PostCriacao(venda);
                foreach (var item in car.Itens)
                {
                    if(item.CarrinhoId != null)
                    { 
                        item.CarrinhoId = null;
                        item.VendaId = venda.VendaId;
                    }
                }
                venda.Itens = car.Itens;
                _vendaRepo.PutEdicao(venda);
            
                return true;
            }
            return false;
        }
            
            

        public CarrinhoModel GetOne(Guid? id)
        {
            return _carrinhoRepo.GetOne(id);
        }
    }
}
