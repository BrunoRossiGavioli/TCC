using System.Collections.Generic;
using TCCESTOQUE.Models;


namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorRepository
    {

        public ICollection<FornecedorModel> GetAll();

        public FornecedorModel GetOne(int? id);

        public void PostCadastro(FornecedorModel fornecedorModel);

        public FornecedorModel GetEditFull(int? id);

        public void PutEdit(FornecedorModel fornecedorModel);

        public void PostExclusao(FornecedorModel fornecedor);

        public FornecedorModel GetByCnpj(string cnpj);

        public FornecedorModel GetByRazaoSocial(string razao);
        public FornecedorModel GetByNomeFantsia(string nome);
        public FornecedorModel GetByEmail(string email);



    }
}
