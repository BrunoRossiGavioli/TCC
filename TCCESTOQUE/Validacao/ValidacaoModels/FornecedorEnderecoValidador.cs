using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorEnderecoValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoValidador()
        {
            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MensagensErroFornecedor.NomeFantasiaVazio)
                .MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMinimo);

            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage(MensagensErroFornecedor.NomeVazio)
            .MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeTamanhoMaximo)
            .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeTamanhoMinimo);

            RuleFor(f => f.Email).NotEmpty().WithMessage(MensagensErroFornecedor.EmailVazio)
                .EmailAddress().WithMessage(MensagensErroFornecedor.EmailFormatoInvalido)
                .MaximumLength(30).WithMessage(MensagensErroFornecedor.EmailTamanhoMaximo)
                .MinimumLength(13).WithMessage(MensagensErroFornecedor.EmailTamanhoMinimo);

            RuleFor(f => f.Telefone).NotEmpty().WithMessage(MensagensErroFornecedor.TelefoneVazio)
                .Length(11).WithMessage(MensagensErroFornecedor.TelefoneTamanho);


            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MensagensErroFornecedor.CnpjVazio)
                .Length(14).WithMessage(MensagensErroFornecedor.CnpjTamanho);
        }
    }
}
