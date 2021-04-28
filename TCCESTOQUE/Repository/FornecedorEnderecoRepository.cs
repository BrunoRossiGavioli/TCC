using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Repository
{
    public class FornecedorEnderecoRepository : IFornecedorEnderecoRepository
    {
        public Task Create(FornecedorEnderecoModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(FornecedorEnderecoModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FornecedorEnderecoModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FornecedorEnderecoModel> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(FornecedorEnderecoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
