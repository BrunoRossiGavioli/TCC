using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorEnderecoRepository _fornecedorEnderecoRepo;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IFornecedorEnderecoRepository fornecedorEnderecoRepo)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorEnderecoRepo = fornecedorEnderecoRepo;
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
            //var validator = new FornecedorEnderecoValidador(_fornecedorRepository).Validate(feviewmodel);
            var validator = new FornecedorEnderecoValidador().Validate(feviewmodel);
            if (!validator.IsValid)
                return false;

            var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
            var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);

            fornecedor.FornecedorId = id;
            endereco.FornecedorId = fornecedor.FornecedorId;

            try
            {
                var resposta = _fornecedorRepository.Incluir(fornecedor);

                
                _fornecedorEnderecoRepository.incluir(endereco);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }



                return _fornecedorRepository.PutEditFull(id, feviewmodel);

            return false;
        }

        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {
            
            

            var validacao = new FornecedorEnderecoValidador().Validate(feviewmodel);

            if (!validacao.IsValid)
                return false;

            var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
            var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);


            var validaBusiness = new FornecedorModelBusinessValidator();

                feviewmodel = FormataValores.FormataValoresFornecedorView(feviewmodel);
                _fornecedorRepository.PostCadastroFull(feviewmodel);
                return true;
            

            return false;
        }
    }
}
