using System.Collections.Generic;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public ICollection<VendaModel> GetIndex()
        {
            return _vendaRepository.GetIndex();
        }

        public VendaModel GetDetalhes(int? id)
        {
            return _vendaRepository.GetDetalhes(id);
        }

        public object GetCriacao(int id)
        {
            return _vendaRepository.GetCricao(id);
        }

        public object PostCricao(VendaViewModel venda)
        {
            var res = new VendaValidador().Validate(venda);
            if (res.IsValid)
                return _vendaRepository.PostCricao(venda);

            return null;
        }

        public VendaModel GetEdicao(int? id)
        {
            return _vendaRepository.GetEdicao(id);
        }

        public object PutEdicao(int id, VendaModel venda)
        {
            return _vendaRepository.PutEdicao(id, venda);
        }

        public VendaModel GetExclusao(int? id)
        {
            return _vendaRepository.GetExclusao(id);
        }

        public VendaModel PostExclusao(int id)
        {
            return _vendaRepository.PostExclusao(id);
        }
    }
}
