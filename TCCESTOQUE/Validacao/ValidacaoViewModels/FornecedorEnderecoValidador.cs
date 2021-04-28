﻿using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class FornecedorEnderecoValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoValidador() //IFornecedorRepository fornecedor)
        {
            //RuleFor(f => f.Cnpj).Must(cnpj => fornecedor.GetByCnpj(cnpj) == null).WithMessage(MensagensErroFornecedor.CnpjJaCadastrado);

            //RuleFor(f => f.RazaoSocial).Must(razaoSocial => fornecedor.GetByRazaoSocial(razaoSocial) == null).WithMessage(MensagensErroFornecedor.RazaoSocialJaCadastrada);
            // RuleFor(f => f.NomeFantasia).Must(nomeFantasia => fornecedor.GetByNomeFantsia(nomeFantasia) == null).WithMessage(MensagensErroFornecedor.NomeFantaziajaCadastrado);
            //  RuleFor(f => f.Email).Must(email => fornecedor.GetByEmail(email) == null).WithMessage(MensagensErroFornecedor.EmailJaCadastrado);

            RuleFor(f => f.NomeFantasia).MaximumLength(80).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroFornecedor.NomeFantasiaTamanhoMinimo);

            RuleFor(f => f.RazaoSocial).NotEmpty().WithMessage(MensagensErroFornecedor.RazaoSocialVazia)
               .MaximumLength(80).WithMessage(MensagensErroFornecedor.RazaoSocialTamanhoMaximo)
               .MinimumLength(3).WithMessage(MensagensErroFornecedor.RazaoSocialTamanhoMinimo);

            When(f => !string.IsNullOrEmpty(f.Email), () =>
            {
               RuleFor(f => f.Email)
                   .EmailAddress().WithMessage(MensagensErroFornecedor.EmailFormatoInvalido)
                   .MaximumLength(80).WithMessage(MensagensErroFornecedor.EmailTamanhoMaximo);
            });

            RuleFor(f => f.Telefone).NotEmpty().WithMessage(MensagensErroFornecedor.TelefoneVazio)
                .Length(14).WithMessage(MensagensErroFornecedor.TelefoneTamanho);


            RuleFor(f => f.Cnpj).NotEmpty().WithMessage(MensagensErroFornecedor.CnpjVazio)
                .Length(18).WithMessage(MensagensErroFornecedor.CnpjTamanho);


            RuleFor(e => e.Cep).Length(10).WithMessage(MensagensDeErroEndereco.CepTamanho);

            RuleFor(e => e.Logradouro).MaximumLength(50).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);

            RuleFor(e => e.Complemento).MaximumLength(50).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.ComplementoVazio);

            RuleFor(e => e.Numero).GreaterThanOrEqualTo(0).WithMessage(MensagensDeErroEndereco.NumeroTamanhoMinimo);

            RuleFor(e => e.Bairro).MaximumLength(50).WithMessage(MensagensDeErroEndereco.BairroTamanhoMaximo)
                .MinimumLength(2).WithMessage(MensagensDeErroEndereco.BairroTamanhoMinimo);

            RuleFor(e => e.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio)
                .MaximumLength(30).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensDeErroEndereco.LocalidadeTamanhoMinimo);

        }
    }
}