using TCCESTOQUE.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Validacao.MensagensDeErro; 

namespace TCCESTOQUE.Validacao.ValidacaoModels 
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
                .MaximumLength(30).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MensagensErroVendedor.EmailTamanhoMinimo);

            RuleFor(v => v.Endereco).NotEmpty().WithMessage(MensagensErroVendedor.EnderecoVazio)
                .MaximumLength(80).WithMessage(MensagensErroVendedor.EnderecoTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensErroVendedor.EnderecoTamanhoMinimo);
                
            RuleFor(v => v.Telefone).NotEmpty().WithMessage(MensagensErroVendedor.TelefoneVazio)
                .Length(11).WithMessage(MensagensErroVendedor.TelefoneTamanho);

                
            RuleFor(v => v.Cpf).NotEmpty().WithMessage(MensagensErroVendedor.CpfVazio)
                .Length(11).WithMessage(MensagensErroVendedor.CpfTamanho);

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
