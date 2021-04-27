using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Validacao.ValidacaoModels.ValidaEdit
{
    public class ClienteEditValidador : AbstractValidator<ClienteEditViewModel>
    {
        public ClienteEditValidador(IClienteRepository cli)
        {
            RuleFor(v => v.Nome).NotEmpty().WithMessage(MensagensErroCliente.NomeVazio)
              .MaximumLength(80).WithMessage(MensagensErroCliente.NomeTamanhoMaximo)
              .MinimumLength(3).WithMessage(MensagensErroCliente.NomeTamanhoMinimo);

            RuleFor(v => v.Cpf).Length(11).WithMessage(MensagensErroCliente.CpfTamanho)
                .Must(cpf => cli.GetByCpf(cpf) == null).WithMessage(MensagensErroCliente.CpfJaCadastrado);

            RuleFor(v => v.Telefone).NotEmpty().WithMessage(MensagensErroCliente.TelefoneVazio)
                .Must(telefone => cli.GetByPhone(telefone) == null).WithMessage(MensagensErroCliente.TelefoneJaCadastrado)
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
                .Must(email => cli.GetbyEmail(email) == null).WithMessage(MensagensErroCliente.EmailJaCadastrado)
               .MaximumLength(30).WithMessage(MensagensErroCliente.EmailTamanhoMaximo)
               .MinimumLength(13).WithMessage(MensagensErroCliente.EmailTamanhoMinimo);
        }
    }
}
