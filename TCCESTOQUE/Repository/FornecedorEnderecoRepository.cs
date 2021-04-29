using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class FornecedorEnderecoRepository : BaseRepository<FornecedorEnderecoModel>, IFornecedorEnderecoRepository
    {
        public FornecedorEnderecoRepository(TCCESTOQUEContext context) : base(context)
        {

        }

        public async Task<bool> Delete(int id)
        {
            var obj = await this.GetOne(id);
            if (obj == null)
                return false;

            var resposta =  base.Delete(obj);
            return true;
        }

        public async Task<FornecedorEnderecoModel> GetOne(int id)
        {
            return _context.FornecedorEnderecoModel.Where(a => a.FornecedorId == id).FirstOrDefault();
        }
    }
}
