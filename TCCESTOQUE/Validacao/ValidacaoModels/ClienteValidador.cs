using FluentValidation;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class ClienteValidador : AbstractValidator<ClienteViewModel>
    {
        public ClienteValidador()
        {
            RuleFor(v => v.Nome).NotEmpty().WithMessage(MensagensErroCliente.NomeVazio)
               .MaximumLength(80).WithMessage(MensagensErroCliente.NomeTamanhoMaximo)
               .MinimumLength(3).WithMessage(MensagensErroCliente.NomeTamanhoMinimo);

            RuleFor(v => v.Telefone).NotEmpty().WithMessage(MensagensErroCliente.TelefoneVazio)
              .Length(11).WithMessage(MensagensErroCliente.TelefoneTamanho);

            RuleFor(e => e.Cep).NotEmpty().WithMessage(MensagensDeErroEndereco.CepVazio)
                .Length(8).WithMessage(MensagensDeErroEndereco.CepTamanho);

            RuleFor(e => e.Logradouro).NotEmpty().WithMessage(MensagensDeErroEndereco.LogradouroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);

            RuleFor(e => e.Complemento).NotEmpty().WithMessage(MensagensDeErroEndereco.ComplementoVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.ComplementoVazio);

            RuleFor(e => e.Numero).NotEmpty().WithMessage(MensagensDeErroEndereco.NumeroVazio)
                .GreaterThanOrEqualTo(0).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMinimo);

            RuleFor(e => e.Bairro).NotEmpty().WithMessage(MensagensDeErroEndereco.BairroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.BairroTamanhoMaximo)
                .MinimumLength(2).WithMessage(MensagensDeErroEndereco.BairroTamanhoMinimo);

            RuleFor(e => e.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMinimo);

            RuleFor(v => v.Email).EmailAddress().WithMessage(MensagensErroCliente.EmailFormatoInvalido)
               .MaximumLength(30).WithMessage(MensagensErroCliente.EmailTamanhoMaximo)
               .MinimumLength(13).WithMessage(MensagensErroCliente.EmailTamanhoMinimo);

            RuleFor(v => v.Cpf).Length(11).WithMessage(MensagensErroCliente.CpfTamanho);
        }
    }
}
