using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Validacao.ValidacaoModels.ValidaEdit
{
    public class VendedorEditValidador : AbstractValidator<VendedorEditViewModel>
    {
        public VendedorEditValidador(IVendedorRepository vend)
        {


            RuleFor(a => a.Email).Must(email => vend.GetByEmail(email) == null || vend.GetByEmail(email) == vend.GetByEmail(email)).WithMessage(MensagensErroVendedor.EmailJaCadastrado);
            RuleFor(a => a.Telefone).Must(telefone => vend.GetByPhone(telefone) == null || vend.GetByPhone(telefone) == vend.GetByPhone(telefone)).WithMessage(MensagensErroVendedor.TelefoneJaCadastrado);

            RuleFor(v => v.Nome).NotEmpty().WithMessage(MensagensErroVendedor.NomeVazio)
                    .MaximumLength(80).WithMessage(MensagensErroVendedor.NomeTamanhoMaximo)
                    .MinimumLength(3).WithMessage(MensagensErroVendedor.NomeTamanhoMinimo);

            RuleFor(v => v.Email).NotEmpty().WithMessage(MensagensErroVendedor.EmailVazio)
                    .EmailAddress().WithMessage(MensagensErroVendedor.EmailFormatoInvalido)
                    .MaximumLength(30).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo)
                    .MinimumLength(13).WithMessage(MensagensErroVendedor.EmailTamanhoMinimo);

            RuleFor(v => v.Senha).NotEmpty().WithMessage(MensagensErroVendedor.SenhaVazia)
                .MaximumLength(50).WithMessage(MensagensErroVendedor.SenhaTamanhoMaximo)
                .MinimumLength(8).WithMessage(MensagensErroVendedor.SenhaTamanhoMinimo);

            RuleFor(v => v.Telefone).Length(11).WithMessage(MensagensErroVendedor.TelefoneTamanho);
        }
    }
}
