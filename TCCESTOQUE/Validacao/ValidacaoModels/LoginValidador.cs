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
    public class LoginValidador : AbstractValidator<VendedorModel>
    {
        public LoginValidador(IVendedorRepository vend, VendedorModel vendedor)
        {
            RuleFor(v => v.Email).Must(email => vend.GetByEmail(email) != null).WithMessage(MensagensErroVendedor.EmailNaoEncontrado);
            RuleFor(v => v.Senha).Must(senha => vend.GetSenha(senha)?.Senha == SecurityService.Criptografar(vendedor.Senha)).WithMessage(MensagensErroVendedor.SenhaIncorreta);
        }
    }
}
