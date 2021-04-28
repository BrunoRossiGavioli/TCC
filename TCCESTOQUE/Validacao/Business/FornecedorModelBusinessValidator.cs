using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.Business
{
    public class FornecedorModelBusinessValidator : AbstractValidator<FornecedorModel>
    {
        public FornecedorModelBusinessValidator(IFornecedorRepository fornecedor)
        {
            RuleFor(f => f.Cnpj).Must(cnpj => fornecedor.GetByCnpj(cnpj) == null).WithMessage(MensagensErroFornecedor.CnpjJaCadastrado);

            RuleFor(f => f.RazaoSocial).Must(razaoSocial => fornecedor.GetByRazaoSocial(razaoSocial) == null).WithMessage(MensagensErroFornecedor.RazaoSocialJaCadastrada);
            RuleFor(f => f.NomeFantasia).Must(nomeFantasia => fornecedor.GetByNomeFantasia(nomeFantasia) == null).WithMessage(MensagensErroFornecedor.NomeFantaziajaCadastrado);
            RuleFor(f => f.Email).Must(email => fornecedor.GetByEmail(email) == null).WithMessage(MensagensErroFornecedor.EmailJaCadastrado);
        }

    }
}
