using FluentValidation;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class VendaValidador : AbstractValidator<VendaViewModel>
    {
        public VendaValidador()
        {

            RuleFor(a => a.ClienteId).NotEmpty().WithMessage(MensagensDeErroVenda.ClienteVazio)
                .GreaterThanOrEqualTo(1).WithMessage(MensagensDeErroVenda.ClienteTamanhoMinimo);

            RuleFor(a => a.VendedorId).NotEmpty().WithMessage(MensagensDeErroVenda.VendedorVazio)
            .GreaterThanOrEqualTo(1).WithMessage(MensagensDeErroVenda.VendedorTamanhoMinimo);

            RuleFor(a => a.ProdutoId).NotEmpty().WithMessage(MensagensDeErroVenda.ProdutoVazio)
            .GreaterThanOrEqualTo(1).WithMessage(MensagensDeErroVenda.ProdutoTamanhoMinimo);


            RuleFor(a => a.DataVenda).NotEmpty().WithMessage(MensagensDeErroVenda.DataVazia);

            RuleFor(a => a.Valor).NotEmpty().WithMessage(MensagensDeErroVenda.ValorVazio)
                .GreaterThanOrEqualTo(1).WithMessage(MensagensDeErroVenda.ValorTamanhoMinimo);

            RuleFor(a => a.Quantidade).NotEmpty().WithMessage(MensagensDeErroVenda.ClienteVazio)
            .GreaterThanOrEqualTo(1).WithMessage(MensagensDeErroVenda.QuantidadeTamanhoMinimo);
        }
    }
}
