﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class EnderecoValidador : AbstractValidator<EnderecoModel>
    {
        public EnderecoValidador()
        {
            RuleFor(e => e.Cep).NotEmpty().WithMessage(MensagensDeErroEndereco.CepVazio)
                .Length(8).WithMessage(MensagensDeErroEndereco.CepTamanho);

            RuleFor(e => e.Logradouro).NotEmpty().WithMessage(MensagensDeErroEndereco.LogradouroVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensDeErroEndereco.LogradouroTamanhoMinimo);

            RuleFor(e => e.Complemento).NotEmpty().WithMessage(MensagensDeErroEndereco.ComplementoVazio)
                .MaximumLength(80).WithMessage(MensagensDeErroEndereco.ComplementoTamanhoMaximo)
                .MinimumLength(10).WithMessage(MensagensDeErroEndereco.ComplementoVazio);

            RuleFor(e => e.Numero).NotEmpty().WithMessage(MensagensDeErroEndereco.NumeroVazio);

            RuleFor(e => e.Bairro).NotEmpty().WithMessage(MensagensDeErroEndereco.BairroVazio);

            RuleFor(e => e.Localidade).NotEmpty().WithMessage(MensagensDeErroEndereco.LocalidadeVazio);

            RuleFor(e => e.Uf).NotEmpty().WithMessage(MensagensDeErroEndereco.UfVazio);
        }
    }
}
