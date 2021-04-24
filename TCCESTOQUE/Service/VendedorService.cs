using AutoMapper;
using System.Linq;
using System.Security.Claims;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.Validacao.ValidacaoModels.ValidaEdit;
using TCCESTOQUE.ValidadorVendedor;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Service
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IMapper _mapper;
        public VendedorService(IVendedorRepository vendedorRepository, IMapper mapper)
        {
            _vendedorRepository = vendedorRepository;
            _mapper = mapper;
        }
        public object GetCriacao()
        {
            return _vendedorRepository.GetCriacao();
        }

        public VendedorModel GetDetalhes(int? id)
        {
            if (id == null)
                return null;

            return _vendedorRepository.GetDetalhes(id);
        }

        public VendedorEditViewModel GetEdicao(int? id)
        {
            return _vendedorRepository.GetEdicao(id);
        }

        public VendedorModel GetExclusao(int? id)
        {
            return _vendedorRepository.GetExclusao(id);
        }

        public bool PostCriacao(VendedorModel vendedorModel)
        {
            var validacao = new VendedorValidador(_vendedorRepository).Validate(vendedorModel);

            if (validacao.IsValid)
            {
                vendedorModel = FormataValores.FormataValoresVendedor(vendedorModel);
                return _vendedorRepository.PostCriacao(vendedorModel);
            }

            return false;
        }

        public bool PutEdicao(int id, VendedorEditViewModel vendedorModel)
        {
            vendedorModel.VendedorId = id;

            var validacao = new VendedorEditValidador(_vendedorRepository).Validate(vendedorModel);
            if (validacao.IsValid)
            {
                vendedorModel = FormataValores.FormataValoresVendedorEdit(vendedorModel);
                return _vendedorRepository.PutEdicao(id, vendedorModel);
            }

            return false;
        }

        public object PostExclusao(int id)
        {
            return _vendedorRepository.PostExclusao(id);
        }
        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel)
        {
            var validacao = new ValidaLogin(_vendedorRepository).Validate(vendedorModel);
            if (validacao.IsValid)
                return _vendedorRepository.PostLogin(vendedorModel);

            return null;
        }

        public object GetEmail(string email)
        {
            return _vendedorRepository.GetByEmail(email);
        }

        public object GetSenha(string senha)
        {
            return _vendedorRepository.GetSenha(senha);
        }
    }
}
