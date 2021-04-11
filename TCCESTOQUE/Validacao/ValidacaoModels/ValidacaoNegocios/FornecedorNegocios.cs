using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels.ValidacaoNegocios
{
    public class FornecedorEnderecoViewModeValidator : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoViewModeValidator(IFornecedorRepository fornecedor)
        {
            RuleFor(f => f.Cnpj).Must(cnpj => fornecedor.GetByCnpj(cnpj) == null).WithMessage(MensagensErroFornecedor.CnpjJaCadastrado);
            RuleFor(f => f.RazaoSocial).Must(razaoSocial => fornecedor.GetByRazaoSocial(razaoSocial) == null).WithMessage(MensagensErroFornecedor.RazaoSocialJaCadastrada);
            RuleFor(f => f.NomeFantasia).Must(nomeFantasia => fornecedor.GetByNomeFantsia(nomeFantasia) == null).WithMessage(MensagensErroFornecedor.NomeFantaziajaCadastrado);
        }
    }
}
