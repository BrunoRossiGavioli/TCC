using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.POCO;

namespace TCCESTOQUE.Repository
{
    public class SenhaRepository : BaseRepository<AlterarSenhaModel>, ISenhaRepository
    {
        public SenhaRepository(TCCESTOQUEContext context) :base(context)
        {

        }

        public override AlterarSenhaModel GetOne(Guid? id)
        {
            return _context.AlterarSenhaModel.Where(m => m.Id == id && !m.Invalida).FirstOrDefault();
        }

        public AlterarSenhaModel GetOneByCodigo(AlterarSenha model)
        {
            return _context.AlterarSenhaModel.Where(m => m.Id == model.TrocaId && m.Codigo == model.Codigo && m.Invalida == false).FirstOrDefault();
            
        }

        public ICollection<AlterarSenhaModel> GetAll(Guid vendedorId)
        {
            throw new NotImplementedException();
        }
    }
}
