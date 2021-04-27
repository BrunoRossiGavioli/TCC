using FluentValidation;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Validacao.ValidacaoModels.ValidaEdit
{
    public class ProdutoEditValidador : AbstractValidator<ProdutoEditViewModel>
    {
        public ProdutoEditValidador()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage(MensagensErroProduto.NomeVazio)
                   .MaximumLength(80).WithMessage(MensagensErroProduto.NomeTamanhoMaximo)
                   .MinimumLength(3).WithMessage(MensagensErroProduto.NomeTamanhoMinimo);

            RuleFor(p => p.Descricao).MaximumLength(30).WithMessage(MensagensErroProduto.DescricaoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroProduto.DescricaoTamanhoMinimo);

            RuleFor(p => p.ValorUnitario).NotEmpty().WithMessage(MensagensErroProduto.ValorUnitarioVazio)
             .GreaterThan(0).WithMessage(MensagensErroProduto.ValorUnitarioMinimo);
        }
    }
}
