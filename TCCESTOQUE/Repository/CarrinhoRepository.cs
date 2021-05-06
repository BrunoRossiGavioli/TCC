using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class CarrinhoRepository : BaseRepository<CarrinhoModel>, ICarrinhoRepository
    {
        public CarrinhoRepository(TCCESTOQUEContext context) : base(context)
        {

        }

        public override CarrinhoModel GetOne(int? id)
        {
            var carrinhoModel = _context.CarrinhoModel
                .Include(c => c.Vendedor)
                .Include(i => i.Itens)
                .FirstOrDefault(m => m.CarrinhoId == id);

            carrinhoModel.Itens = _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Produto.Fornecedor)
                .Where(i => i.CarrinhoId == id).ToList();

            return carrinhoModel;
        }

        public ICollection<CarrinhoModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
