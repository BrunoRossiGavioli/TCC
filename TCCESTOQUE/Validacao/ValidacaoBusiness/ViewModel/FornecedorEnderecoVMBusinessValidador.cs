using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Validacao.MensagensDeErro;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.ValidacaoBusiness.ViewModel
{
    public class FornecedorEnderecoVMBusinessValidador : AbstractValidator<FornecedorEnderecoViewModel>
    {
        public FornecedorEnderecoVMBusinessValidador(IFornecedorRepository fornecedor)
        {
            When(fe => fornecedor.GetByCnpj(fe.Cnpj)?.FornecedorId != fe.FornecedorId, () => 
            {
                RuleFor(f => f.Cnpj).Must(cnpj => fornecedor.GetByCnpj(cnpj) == null)
                .WithMessage(MensagensErroFornecedor.CnpjJaCadastrado);
            });
            
            When(fe => fornecedor.GetByRazaoSocial(fe.RazaoSocial)?.FornecedorId != fe.FornecedorId, () => 
            {
                RuleFor(f => f.RazaoSocial).Must(razaoSocial => fornecedor.GetByRazaoSocial(razaoSocial) == null)
                .WithMessage(MensagensErroFornecedor.RazaoSocialJaCadastrada);
            });
            
            When(fe => fornecedor.GetByNomeFantsia(fe.NomeFantasia)?.FornecedorId != fe.FornecedorId, () => 
            {
                RuleFor(f => f.NomeFantasia).Must(nomeFantasia => fornecedor.GetByNomeFantsia(nomeFantasia) == null)
               .WithMessage(MensagensErroFornecedor.NomeFantasiajaCadastrado);
            });

            When(fe => fornecedor.GetByEmail(fe.Email)?.FornecedorId != fe.FornecedorId, () =>
            {
                RuleFor(f => f.Email).Must(email => fornecedor.GetByEmail(email) == null)
                .WithMessage(MensagensDeErroPadrao.EmailJaCadastrado);
            });
        }
    }
}
