using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorEnderecoValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoValidador(IFornecedorRepository fornecedor)
        {
            RuleFor(f => f.Cnpj).Must(cnpj => fornecedor.GetByCnpj(cnpj) == null).WithMessage(MensagensErroFornecedor.CnpjJaCadastrado);
            RuleFor(f => f.RazaoSocial).Must(razaoSocial => fornecedor.GetByRazaoSocial(razaoSocial) == null).WithMessage(MensagensErroFornecedor.RazaoSocialJaCadastrada);
            RuleFor(f => f.NomeFantasia).Must(nomeFantasia => fornecedor.GetByNomeFantsia(nomeFantasia) == null).WithMessage(MensagensErroFornecedor.NomeFantaziajaCadastrado);

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

            RuleFor(f => f.Telefone).NotEmpty().WithMessage(MensagensErroFornecedor.TelefoneVazio)
                .Length(11).WithMessage(MensagensErroFornecedor.TelefoneTamanho);


            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MensagensErroFornecedor.CnpjVazio)
                .Length(14).WithMessage(MensagensErroFornecedor.CnpjTamanho);


            RuleFor(f => f.Cep).NotEmpty().WithMessage(MensagensDeErroEndereco.CepVazio)
                .Length(8).WithMessage(MensagensDeErroEndereco.CepTamanho);

            RuleFor(f => f.Logradouro).NotEmpty().WithMessage(MensagensDeErroEndereco.LogradouroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);

            RuleFor(f => f.Complemento).NotEmpty().WithMessage(MensagensDeErroEndereco.ComplementoVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensDeErroEndereco.ComplementoVazio);

            RuleFor(f => f.Numero).NotEmpty().WithMessage(MensagensDeErroEndereco.NumeroVazio)
                .GreaterThanOrEqualTo(1).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMinimo);

            RuleFor(f => f.Bairro).NotEmpty().WithMessage(MensagensDeErroEndereco.BairroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.BairroTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensDeErroEndereco.BairroTamanhoMinimo);

            RuleFor(f => f.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMinimo);

        }
    }
}
