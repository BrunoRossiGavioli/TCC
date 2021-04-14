using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        public object GetIndex();

        public FornecedorModel GetDetalhes(int? id);

        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(int? id);

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel);

        public FornecedorModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public FornecedorModel GetByCnpj(string cnpj);

        public FornecedorModel GetByRazaoSocial(string razao);
        public FornecedorModel GetByNomeFantsia(string nome);
        public FornecedorModel GetByEmail(string email);



    }
}
