using TCCESTOQUE.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Validacao.MensagensDeErro; 

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorValidador : AbstractValidator<FornecedorModel>
    {
        public FornecedorValidador()
        {                        
            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MenssagensErroFornecedor.NomeFantasiaVazio)
                .MaximumLength(80).WithMessage(MenssagensErroFornecedor.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(MenssagensErroFornecedor.NomeFantasiaTamanhoMinimo);

                RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MenssagensErroFornecedor.NomeVazio)
                .MaximumLength(80).WithMessage(MenssagensErroFornecedor.NomeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MenssagensErroFornecedor.NomeTamanhoMinimo);

            RuleFor(f => f.Email).NotEmpty().WithMessage(MenssagensErroFornecedor.EmailVazio)
                .EmailAddress().WithMessage(MenssagensErroFornecedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MenssagensErroFornecedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MenssagensErroFornecedor.EmailTamanhoMinimo);
                
            RuleFor(f => f.Telefone).NotEmpty().WithMessage(MenssagensErroFornecedor.TelefoneVazio)
                .Length(11).WithMessage(MenssagensErroFornecedor.TelefoneTamanho);

                
            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MenssagensErroFornecedor.CnpjVazio)
                .Length(14).WithMessage(MenssagensErroFornecedor.CnpjTamanho);            
        
        }
        
    }
}
