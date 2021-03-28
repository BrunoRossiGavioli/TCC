using TCCESTOQUE.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.ValidadorVendedor
{
    public class VendedorValidador : AbstractValidator<VendedorModel>
    {
        public VendedorValidador()
        {            
            RuleFor(v => v.Nome).NotEmpty().WithMessage(MensagensErroVendedor.NomeVazio)
                .NotNull().WithMessage(MensagensErroVendedor.NomeVazio)
                .MaximumLength(80).WithMessage(MensagensErroVendedor.NomeTamanhoMaximo)
                .MinimumLength(4).WithMessage(MensagensErroVendedor.NomeTamanhoMinimo);

            RuleFor(v => v.Email).NotEmpty().WithMessage(MensagensErroVendedor.EmailVazio)
                .NotNull().WithMessage(MensagensErroVendedor.EmailVazio)
                .MaximumLength(30).WithMessage(MensagensErroVendedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MensagensErroVendedor.EmailTamanhoMinimo);

            RuleFor(v => v.Endereco).NotEmpty().WithMessage(MensagensErroVendedor.EnderecoVazio)
                .NotNull().WithMessage(MensagensErroVendedor.EnderecoVazio)
                .MaximumLength(80).WithMessage(MensagensErroVendedor.EnderecoTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensErroVendedor.EnderecoTamanhoMinimo);

            RuleFor(v => v.Telefone).NotEmpty().WithMessage(MensagensErroVendedor.TelefoneVazio)
                .NotNull().WithMessage(MensagensErroVendedor.TelefoneVazio)
                .MaximumLength(11).WithMessage(MensagensErroVendedor.TelefoneTamanhoMaximo)
                .MinimumLength(11).WithMessage(MensagensErroVendedor.TelefoneTamanhoMinimo);

            RuleFor(v => v.Senha).NotEmpty().WithMessage(MensagensErroVendedor.SenhaVazia)
                .NotNull().WithMessage(MensagensErroVendedor.SenhaVazia)
                .MaximumLength(50).WithMessage(MensagensErroVendedor.SenhaTamanhoMaximo)
                .MinimumLength(8).WithMessage(MensagensErroVendedor.SenhaTamanhoMinimo);

            RuleFor(v => v.Cpf).NotEmpty().WithMessage(MensagensErroVendedor.CpfVazio)
                .NotNull().WithMessage(MensagensErroVendedor.CpfVazio)
                .MaximumLength(11).WithMessage(MensagensErroVendedor.CpfTamanhoMaximo)
                .MinimumLength(11).WithMessage(MensagensErroVendedor.CpfTamanhoMinimo);

             RuleFor(v => v.DataNascimento).NotEmpty().WithMessage(MensagensErroVendedor.DataNascimentoVazia)
                .NotNull().WithMessage(MensagensErroVendedor.DataNascimentoVazia)
                .LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage(MensagensErroVendedor.DataTamanhoMinimo)
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-17)).WithMessage(MensagensErroVendedor.DataNascimentoTamanhoMaximo);
    
        }
    }
}