using FluentValidation;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorValidador : AbstractValidator<FornecedorModel>
    {
        public FornecedorValidador()
        {
            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MensagensErroFornecedor.NomeFantasiaVazio)
                .MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMinimo);

            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MensagensErroFornecedor.NomeVazio)
            .MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeTamanhoMaximo)
            .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeTamanhoMinimo);

            RuleFor(f => f.Email).NotEmpty().WithMessage(MensagensErroFornecedor.EmailVazio)
                .EmailAddress().WithMessage(MensagensErroFornecedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MensagensErroFornecedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MensagensErroFornecedor.EmailTamanhoMinimo);

            RuleFor(f => f.Telefone).NotEmpty().WithMessage(MensagensErroFornecedor.TelefoneVazio)
                .Length(14).WithMessage(MensagensErroFornecedor.TelefoneTamanho);

            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MensagensErroFornecedor.CnpjVazio)
                .Length(18).WithMessage(MensagensErroFornecedor.CnpjTamanho);
        }
    }
}