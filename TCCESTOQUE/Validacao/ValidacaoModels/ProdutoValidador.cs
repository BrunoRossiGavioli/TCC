using FluentValidation;
using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels
{
    public class ProdutoValidador : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidador()
        { 

        RuleFor(p => p.Nome).NotEmpty().WithMessage(MensagensErroProduto.NomeVazio)
                .MaximumLength(80).WithMessage(MensagensErroProduto.NomeTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroProduto.NomeTamanhoMinimo);
 
            RuleFor(p => p.Descricao).NotEmpty().WithMessage(MensagensErroProduto.DescricaoVazia)
                .MaximumLength(30).WithMessage(MensagensErroProduto.DescricaoTamanhoMaximo)
                .MinimumLength(3).WithMessage(MensagensErroProduto.DescricaoTamanhoMinimo);

            RuleFor(p => p.Custo).NotEmpty().WithMessage(MensagensErroProduto.CustoVazio)
                .GreaterThan(0).WithMessage(MensagensErroProduto.CustoMinimo);
                
            RuleFor(p => p.ValorUnitario).NotEmpty().WithMessage(MensagensErroProduto.ValorUnitarioVazio)
                .GreaterThan(0).WithMessage(MensagensErroProduto.ValorUnitarioMinimo);
                
            RuleFor(p => p.Quantidade).NotEmpty().WithMessage(MensagensErroProduto.QuantidadeVazia)
                .GreaterThan(0).WithMessage(MensagensErroProduto.QuantidadeMinima);           

             RuleFor(p => p.DataEntrada).NotEmpty().WithMessage(MensagensErroProduto.DataEntradaVazia)
                .Must(DataMinima).WithMessage(MensagensErroProduto.DataDeEntradaFutura); 
        }
        private static bool DataMinima(DateTime data)
        { 
           return data <= DateTime.Now.AddMinutes(1) ;
        }        
    }
}
