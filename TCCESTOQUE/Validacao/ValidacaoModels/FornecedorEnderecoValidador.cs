using FluentValidation;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorEnderecoValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoValidador()
        {
            When(f => !string.IsNullOrEmpty(f.NomeFantasia), () =>
            {
                RuleFor(f => f.NomeFantasia)
                .MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMinimo);
            });
            RuleFor(f => f.RazaoSocial).NotEmpty().WithMessage(MensagensErroFornecedor.RazaoSocialVazia)
               .MaximumLength(80).WithMessage(MensagensErroFornecedor.RazaoSocialTamanhoMaximo)
               .MinimumLength(3).WithMessage(MensagensErroFornecedor.RazaoSocialTamanhoMinimo);

            When(f => !string.IsNullOrEmpty(f.Email), () =>
            {
                RuleFor(f => f.Email)
                    .EmailAddress().WithMessage(MensagensErroFornecedor.EmailFormatoInvalido)
                    .MaximumLength(80).WithMessage(MensagensErroFornecedor.EmailTamanhoMaximo);
            });
            RuleFor(f => f.Telefone).NotEmpty().WithMessage(MensagensErroFornecedor.TelefoneVazio)
            .Length(14).WithMessage(MensagensErroFornecedor.TelefoneTamanho);

            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MensagensErroFornecedor.CnpjVazio)
                .Length(18).WithMessage(MensagensErroFornecedor.CnpjTamanho);


            RuleFor(e => e.Cep).NotEmpty().Length(9).WithMessage(MensagensDeErroEndereco.CepTamanho);
            When(f => !string.IsNullOrEmpty(f.Logradouro), () =>
            {
                RuleFor(e => e.Logradouro).MaximumLength(50).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);
            });
            When(f => !string.IsNullOrEmpty(f.Complemento), () =>
            {
                RuleFor(e => e.Complemento).MaximumLength(50).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.ComplementoVazio);
            });
            RuleFor(e => e.Numero).GreaterThan(0).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMinimo);

            When(f => !string.IsNullOrEmpty(f.Bairro), () =>
            {
                RuleFor(e => e.Bairro).MaximumLength(50).WithMessage(MensagensDeErroEndereco.BairroTamanhoMaximo)
                .MinimumLength(2).WithMessage(MensagensDeErroEndereco.BairroTamanhoMinimo);
            });

            RuleFor(e => e.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio)
            .MaximumLength(30).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMaximo)
            .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMinimo);
        }
    }
}
