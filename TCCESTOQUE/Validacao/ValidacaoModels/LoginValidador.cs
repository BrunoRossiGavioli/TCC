using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class LoginValidador : AbstractValidator<VendedorModel>
    {
        public LoginValidador(IVendedorRepository vendedor)
        {
            RuleFor(v => v.Email).Must(email => vendedor.GetByEmail(email) != null).WithMessage(MensagensErroVendedor.EmailNaoEncontrado)
                    .NotEmpty().WithMessage(MensagensErroVendedor.EmailVazio)
                    .EmailAddress().WithMessage(MensagensErroVendedor.EmailFormatoInvalido)
                    .MaximumLength(80).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo)
                    .MinimumLength(13).WithMessage(MensagensErroVendedor.EmailTamanhoMinimo);
        }
    }
}
