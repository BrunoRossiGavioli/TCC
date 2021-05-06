using FluentValidation;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class VendaViewModelValidador : AbstractValidator<VendaViewModel>
    {
        public VendaViewModelValidador()
        {
            RuleFor(a => a.Quantidade).NotEmpty().WithMessage(MensagensDeErroVenda.ClienteVazio)
            .GreaterThan(0).WithMessage(MensagensDeErroVenda.QuantidadeTamanhoMinimo);
        }
    }
}