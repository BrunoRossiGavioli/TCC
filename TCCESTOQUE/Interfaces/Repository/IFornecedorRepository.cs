using TCCESTOQUE.Models;


namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorRepository : IBaseRepository<FornecedorModel>
    {
        public FornecedorModel GetByCnpj(string cnpj);
        public FornecedorModel GetByPhone(string phone);

        public FornecedorModel GetByRazaoSocial(string razao);

        public FornecedorModel GetByNomeFantsia(string nome);

        public FornecedorModel GetByEmail(string email);
    }
}
