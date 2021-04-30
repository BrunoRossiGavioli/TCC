using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        public object GetIndex();

        public FornecedorModel GetDetalhes(int? id);

        public void PostCadastro(FornecedorModel fornecedorModel);

        public FornecedorModel GetEditFull(int? id);

        public void PutEdit(FornecedorModel fornecedorModel);

        public FornecedorModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public FornecedorModel GetByCnpj(string cnpj);

        public FornecedorModel GetByRazaoSocial(string razao);
        public FornecedorModel GetByNomeFantsia(string nome);
        public FornecedorModel GetByEmail(string email);



    }
}
