using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorEnderecoRepository
    {
        public void PostCadastro(FornecedorEnderecoModel endereco);
        public void PutEdit(FornecedorEnderecoModel endereco);

        public FornecedorEnderecoModel FindWhereFornecedorId(FornecedorModel fornecedor);
    }
}
