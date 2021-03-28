using TCCESTOQUE.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Validacao.MenssagensDeErro;

namespace TCCESTOQUE.ValidadorVendedor
{
    public class ValidadorVendedor : AbstractValidator<VendedorModel>
    {
        public ValidadorVendedor()
        {            
            RuleFor(v => v.Nome).NotEmpty().WithMessage(MenssagensErroVendedor.NomeVazio)
                .NotNull().WithMessage(MenssagensErroVendedor.NomeVazio)
                .MaximumLength(80).WithMessage(MenssagensErroVendedor.NomeTamanhoMaximo)
                .MinimumLength(4).WithMessage(MenssagensErroVendedor.NomeTamanhoMinimo);

            RuleFor(v => v.Email).NotEmpty().WithMessage(MenssagensErroVendedor.EmailVazio)
                .NotNull().WithMessage(MenssagensErroVendedor.EmailVazio)
                .MaximumLength(30).WithMessage(MenssagensErroVendedor.EmailTamanhoMaximo)
                .MinimumLength(10).WithMessage(MenssagensErroVendedor.EmailTamanhoMinimo);

            RuleFor(v => v.Endereco).NotEmpty().WithMessage(MenssagensErroVendedor.EnderecoVazio)
                .NotNull().WithMessage(MenssagensErroVendedor.EnderecoVazio)
                .MaximumLength(80).WithMessage(MenssagensErroVendedor.EnderecoTamanhoMaximo)
                .MinimumLength(10).WithMessage(MenssagensErroVendedor.EnderecoTamanhoMinimo);

            RuleFor(v => v.Telefone).NotEmpty().WithMessage(MenssagensErroVendedor.TelefoneVazio)
                .NotNull().WithMessage(MenssagensErroVendedor.TelefoneVazio)
                .MaximumLength(11).WithMessage(MenssagensErroVendedor.TelefoneTamanhoMaximo)
                .MinimumLength(11).WithMessage(MenssagensErroVendedor.TelefoneTamanhoMinimo);

            RuleFor(v => v.Senha).NotEmpty().WithMessage(MenssagensErroVendedor.SenhaVazia)
                .NotNull().WithMessage(MenssagensErroVendedor.SenhaVazia)
                .MaximumLength(50).WithMessage(MenssagensErroVendedor.SenhaTamanhoMaximo)
                .MinimumLength(8).WithMessage(MenssagensErroVendedor.SenhaTamanhoMinimo);

            RuleFor(v => v.Cpf).NotEmpty().WithMessage(MenssagensErroVendedor.CpfVazio)
                .NotNull().WithMessage(MenssagensErroVendedor.CpfVazio)
                .MaximumLength(11).WithMessage(MenssagensErroVendedor.CpfTamanhoMaximo)
                .MinimumLength(11).WithMessage(MenssagensErroVendedor.CpfTamanhoMinimo);

             RuleFor(v => v.DataNascimento).NotEmpty().WithMessage(MenssagensErroVendedor.DataNascimentoVazia)
                .NotNull().WithMessage(MenssagensErroVendedor.DataNascimentoVazia)
                .LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage(MenssagensErroVendedor.DataTamanhoMinimo)
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-17)).WithMessage(MenssagensErroVendedor.DataNascimentoTamanhoMaximo);
    
        }
    }
}