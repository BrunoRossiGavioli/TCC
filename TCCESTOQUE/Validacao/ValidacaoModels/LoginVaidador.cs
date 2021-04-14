using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class LoginVaidador : AbstractValidator<VendedorModel>
    {
        public LoginVaidador(IVendedorRepository vend)
        {
            RuleFor(v => v.Email).Must(email => vend.GetByEmail(email)!= null).WithMessage(MensagensErroVendedor.EmailNaoEncontrado)
            .NotEmpty().WithMessage(MensagensErroVendedor.EmailVazio)
                .EmailAddress().WithMessage(MensagensErroVendedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MensagensErroVendedor.EmailTamanhoMinimo);

            RuleFor(v => v.Senha).Must(senha => vend.GetSenha(senha)!= null).WithMessage(MensagensErroVendedor.SenhaIncorreta)
                .NotEmpty().WithMessage(MensagensErroVendedor.SenhaVazia)
                .MaximumLength(50).WithMessage(MensagensErroVendedor.SenhaTamanhoMaximo)
                .MinimumLength(8).WithMessage(MensagensErroVendedor.SenhaTamanhoMinimo);
        }
    }
}
