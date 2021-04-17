using System.Linq;
using System.Security.Claims;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ValidadorVendedor;

namespace TCCESTOQUE.Service
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        public VendedorService(IVendedorRepository vendedorRepository)
        {
            _vendedorRepository = vendedorRepository;
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

        public VendedorModel GetEdicao(int? id)
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

        public bool PutEdicao(int id, VendedorModel vendedorModel)
        {
            vendedorModel.VendedorId = id;

            var validacao = new VendedorValidador(_vendedorRepository).Validate(vendedorModel);

            if (validacao.IsValid)
            {
                vendedorModel = FormataValores.FormataValoresVendedor(vendedorModel);
                return _vendedorRepository.PutEdicao(id, vendedorModel);
            }

            return false;
        }

        public object PostExclusao(int id)
        {
            return _vendedorRepository.PostExclusao(id);
        }

        public ClaimsPrincipal PostLogin(VendedorModel vendedorModel)
        {
            return _vendedorRepository.PostLogin(vendedorModel);

        }
    }
}
