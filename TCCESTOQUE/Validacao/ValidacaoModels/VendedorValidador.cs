using FluentValidation;
using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.ValidadorVendedor
{
    public class VendedorValidador : AbstractValidator<VendedorModel>
    {
        public VendedorValidador()
        {
            RuleFor(v => v.Nome).NotEmpty().WithMessage(MensagensErroVendedor.NomeVazio)
                .MaximumLength(80).WithMessage(MensagensErroVendedor.NomeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroVendedor.NomeTamanhoMinimo);

            RuleFor(v => v.Email).NotEmpty().WithMessage(MensagensErroVendedor.EmailVazio)
                .EmailAddress().WithMessage(MensagensErroVendedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo);

            RuleFor(v => v.Senha).NotEmpty().WithMessage(MensagensErroVendedor.SenhaVazia)
            .MaximumLength(50).WithMessage(MensagensErroVendedor.SenhaTamanhoMaximo)
            .MinimumLength(8).WithMessage(MensagensErroVendedor.SenhaTamanhoMinimo);

            RuleFor(v => v.DataNascimento).NotEmpty().WithMessage(MensagensErroVendedor.DataNascimentoVazia)
          .Must(IdadeMinima).WithMessage(MensagensErroVendedor.DataTamanhoMinimo);

            RuleFor(v => v.Telefone).Length(14).WithMessage(MensagensErroVendedor.TelefoneTamanho);

            RuleFor(v => v.Cpf).Length(14).WithMessage(MensagensErroVendedor.CpfTamanho);
        }
        private static bool IdadeMinima(DateTime data)
        {
            return data <= DateTime.Today.AddYears(-18);
        }

    }
}