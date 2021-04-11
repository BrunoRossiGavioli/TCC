using System.Linq;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.Validacao.ValidacaoModels.ValidacaoNegocios;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public object GetIndex()
        {
            return _fornecedorRepository.GetIndex();
        }
        public FornecedorModel GetDetalhes(int? id)
        {
            if (id == null)
                return null;

            return _fornecedorRepository.GetDetalhes(id);
        }

        public FornecedorModel GetExclusao(int? id)
        {
            if (id == null)
                return null;

            return _fornecedorRepository.GetExclusao(id);
        }

        public object PostExclusao(int id)
        {
           return _fornecedorRepository.PostExclusao(id);
        }

        public FornecedorEnderecoViewModel GetEditFull(int? id)
        {
            return _fornecedorRepository.GetEditFull(id);
        }

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel)
        {
            var validator = new FornecedorEnderecoValidador().Validate(feviewmodel);
            if(validator.IsValid)
                return _fornecedorRepository.PutEditFull(id, feviewmodel);

            return false;
        }

        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {           
            var validacao = new FornecedorEnderecoValidador().Validate(feviewmodel);

            if (!validacao.IsValid)
            {
                var erros = validacao.Errors.Select(a => a.ErrorMessage).ToList();
                return false;
            }

            var validacaoNegocios = new FornecedorEnderecoViewModeValidator(_fornecedorRepository).Validate(feviewmodel);

            if (!validacaoNegocios.IsValid)
            {
                var erros = validacaoNegocios.Errors.Select(a => a.ErrorMessage).ToList();
                return false;
            }
            feviewmodel = FormataValores.FormataValoresFornecedorView(feviewmodel);
            _fornecedorRepository.PostCadastroFull(feviewmodel);
            return true;
        }
    }
}
