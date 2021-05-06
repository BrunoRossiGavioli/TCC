using FluentValidation.Results;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendaService : IBaseService<VendaModel>
    {
        public ValidationResult PostCricao(VendaViewModel venda);

        public VendaModel GetEdicao(int? id);

        public object PutEdicao(int id, VendaModel venda);

        public bool PostExclusao(int id);
    }
}
