using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class ValidaLogin : AbstractValidator<LoginVendedorViewModel>
    {
        public ValidaLogin(IVendedorRepository vend)
        {
            RuleFor(a => a.Email).Must(email => vend.GetByEmail(email) != null).WithMessage(MensagensErroVendedor.EmailNaoEncontrado);
            RuleFor(a => a.Senha).Must(senha => vend.GetSenha(senha) != null).WithMessage(MensagensErroVendedor.SenhaIncorreta);
        }
    }
}
