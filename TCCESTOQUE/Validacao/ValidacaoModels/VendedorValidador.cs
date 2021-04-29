using FluentValidation;
using System;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.ValidadorVendedor
{
    public class VendedorValidador : AbstractValidator<VendedorModel>
    {
        public VendedorValidador()
        {
            //RuleFor(a => a.Cpf).Must(cpf => vend.GetByCpf(cpf) == null).WithMessage(MensagensErroVendedor.CpfjaCadastrado);
            //RuleFor(a => a.Email).Must(email => vend.GetByEmail(email) == null).WithMessage(MensagensErroVendedor.EmailJaCadastrado);
            //RuleFor(a => a.Telefone).Must(telefone => vend.GetByPhone(telefone) == null).WithMessage(MensagensErroVendedor.TelefoneJaCadastrado);

            RuleFor(v => v.Nome).NotEmpty().WithMessage(MensagensErroVendedor.NomeVazio)
                .MaximumLength(80).WithMessage(MensagensErroVendedor.NomeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroVendedor.NomeTamanhoMinimo);

            RuleFor(v => v.Email).NotEmpty().WithMessage(MensagensErroVendedor.EmailVazio)
                .EmailAddress().WithMessage(MensagensErroVendedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo);

            When(v => !string.IsNullOrEmpty(v.Telefone), () =>
            {
                RuleFor(v => v.Telefone).Length(14).WithMessage(MensagensErroVendedor.TelefoneTamanho);

            });
            When(v => !string.IsNullOrEmpty(v.Cpf), () =>
            {
                RuleFor(v => v.Cpf).Length(14).WithMessage(MensagensErroVendedor.CpfTamanho);
            });
          

            RuleFor(v => v.Senha).NotEmpty().WithMessage(MensagensErroVendedor.SenhaVazia)
                .MaximumLength(50).WithMessage(MensagensErroVendedor.SenhaTamanhoMaximo)
                .MinimumLength(8).WithMessage(MensagensErroVendedor.SenhaTamanhoMinimo);

            RuleFor(v => v.DataNascimento).NotEmpty().WithMessage(MensagensErroVendedor.DataNascimentoVazia)
               .Must(IdadeMinima).WithMessage(MensagensErroVendedor.DataTamanhoMinimo);
        }
        private static bool IdadeMinima(DateTime data)
        {
            return data <= DateTime.Today.AddYears(-18);
        }

    }
}
