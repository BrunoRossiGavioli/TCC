using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoBusiness
{
    public class FornecedorEnderecoBusinessValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoBusinessValidador(IFornecedorRepository fornecedor)
        {
            When(fe => fornecedor.GetByCnpj(fe.Cnpj)?.FornecedorId != fe.FornecedorId, () =>
            {
                RuleFor(f => f.Cnpj).Must(cnpj => fornecedor.GetByCnpj(cnpj) == null)
                .WithMessage(MensagensErroFornecedor.CnpjJaCadastrado);
            });
            
            When(fe => fornecedor.GetByPhone(fe.Telefone)?.FornecedorId != fe.FornecedorId, () =>
            {
                RuleFor(f => f.Telefone).Must(telefone => fornecedor.GetByPhone(telefone) == null)
                .WithMessage(MensagensErroFornecedor.TelefoneVazio);
            });

            When(fe => fornecedor.GetByRazaoSocial(fe.RazaoSocial)?.FornecedorId != fe.FornecedorId, () =>
            {
                RuleFor(f => f.RazaoSocial).Must(razaoSocial => fornecedor.GetByRazaoSocial(razaoSocial) == null)
                .WithMessage(MensagensErroFornecedor.RazaoSocialJaCadastrada);
            });

            When(fe => fornecedor.GetByNomeFantsia(fe.NomeFantasia)?.FornecedorId != fe.FornecedorId, () =>
            {
                RuleFor(f => f.NomeFantasia).Must(nomeFantasia => fornecedor.GetByNomeFantsia(nomeFantasia) == null)
               .WithMessage(MensagensErroFornecedor.NomeFantaziajaCadastrado);
            });

            When(fe => fornecedor.GetByEmail(fe.Email)?.FornecedorId != fe.FornecedorId, () =>
            {
                RuleFor(f => f.Email).Must(email => fornecedor.GetByEmail(email) == null)
                .WithMessage(MensagensErroFornecedor.EmailJaCadastrado);
            });
        }
    }
}
