using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorRepository : IBaseRepository<FornecedorModel>
    {
        public FornecedorModel GetByCnpj(string cnpj);
        public FornecedorModel GetByRazaoSocial(string razao);
        public FornecedorModel GetByNomeFantasia(string nome);
        public FornecedorModel GetByEmail(string email);



    }
}
