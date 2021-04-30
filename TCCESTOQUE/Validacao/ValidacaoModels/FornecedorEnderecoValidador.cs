using FluentValidation;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorEnderecoValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoValidador()
        {
            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MensagensErroFornecedor.NomeFantasiaVazio)
                .MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMinimo);

            RuleFor(f => f.RazaoSocial).NotEmpty().WithMessage(MensagensErroFornecedor.RazaoSocialVazia)
               .MaximumLength(80).WithMessage(MensagensErroFornecedor.RazaoSocialTamanhoMaximo)
               .MinimumLength(3).WithMessage(MensagensErroFornecedor.RazaoSocialTamanhoMinimo);

            RuleFor(f => f.Email).NotEmpty().WithMessage(MensagensErroFornecedor.EmailVazio)
                .EmailAddress().WithMessage(MensagensErroFornecedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MensagensErroFornecedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MensagensErroFornecedor.EmailTamanhoMinimo);

            RuleFor(f => f.Telefone).Length(11).WithMessage(MensagensErroFornecedor.TelefoneTamanho);


            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MensagensErroFornecedor.CnpjVazio)
                .Length(14).WithMessage(MensagensErroFornecedor.CnpjTamanho);


            RuleFor(e => e.Cep).NotEmpty().WithMessage(MensagensDeErroEndereco.CepVazio)
                .Length(8).WithMessage(MensagensDeErroEndereco.CepTamanho);

            RuleFor(e => e.Logradouro).MaximumLength(80).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);

            RuleFor(e => e.Complemento).MaximumLength(80).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.ComplementoVazio);

            RuleFor(e => e.Numero).LessThanOrEqualTo(999999999).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMaximo)
                .GreaterThanOrEqualTo(0).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMinimo);

            RuleFor(e => e.Bairro).MaximumLength(80).WithMessage(MensagensDeErroEndereco.BairroTamanhoMaximo)
                .MinimumLength(2).WithMessage(MensagensDeErroEndereco.BairroTamanhoMinimo);

            RuleFor(e => e.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMinimo);

        }
    }
}
