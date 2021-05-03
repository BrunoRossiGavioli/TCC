using FluentValidation;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class EnderecoValidador : AbstractValidator<EnderecoModel>
    {
        public EnderecoValidador()
        {
            RuleFor(e => e.Cep).NotEmpty().WithMessage(MensagensDeErroEndereco.CepVazio)
                .Length(9).WithMessage(MensagensDeErroEndereco.CepTamanho);

            RuleFor(e => e.Logradouro).NotEmpty().WithMessage(MensagensDeErroEndereco.LogradouroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);

            RuleFor(e => e.Complemento).NotEmpty().WithMessage(MensagensDeErroEndereco.ComplementoVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.ComplementoVazio);

            RuleFor(e => e.Numero).NotEmpty().WithMessage(MensagensDeErroEndereco.NumeroVazio)
                .GreaterThan(0).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMinimo);

            RuleFor(e => e.Bairro).NotEmpty().WithMessage(MensagensDeErroEndereco.BairroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.BairroTamanhoMaximo)
                .MinimumLength(2).WithMessage(MensagensDeErroEndereco.BairroTamanhoMinimo);

            RuleFor(e => e.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMinimo);


            RuleFor(v => v.Uf).NotEmpty().WithMessage(MensagensDeErroEndereco.UfVazio)
             .Length(2).WithMessage(MensagensDeErroEndereco.UfTamanho);
        }

    }
}
