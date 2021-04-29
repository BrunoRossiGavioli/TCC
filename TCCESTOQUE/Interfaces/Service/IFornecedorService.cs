using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService : IBaseService<FornecedorModel>
    {
        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(int? id);

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel);


    }
}
