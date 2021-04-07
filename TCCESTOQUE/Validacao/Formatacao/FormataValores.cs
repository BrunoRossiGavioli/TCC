using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using System.Globalization;
using System.Threading;

namespace TCCESTOQUE.Validacao.Formatacao
{
    public class FormataValores
    { 
        public static VendedorModel FormataValoresVendedor(VendedorModel vendedorModel)
        {
            vendedorModel.Nome = vendedorModel.Nome.ToUpper().Trim();
            vendedorModel.Endereco = vendedorModel.Endereco.ToUpper().Trim();
            vendedorModel.Cpf = vendedorModel.Cpf.Trim();
            vendedorModel.Telefone = vendedorModel.Telefone.Trim();
            vendedorModel.Email = vendedorModel.Email.Trim();
            vendedorModel.Senha = SecurityService.Criptografar(vendedorModel.Senha);

            return vendedorModel;
        }
        public static FornecedorModel FormataValoresFornecedor(FornecedorModel fornecedorModel)
        {
            fornecedorModel.Nome = fornecedorModel.Nome.ToUpper().Trim();
            fornecedorModel.NomeFantasia = fornecedorModel.NomeFantasia.ToUpper().Trim();
            fornecedorModel.Email = fornecedorModel.Email.ToUpper().Trim();            
            fornecedorModel.Cnpj = fornecedorModel.Cnpj.Trim(); 
            fornecedorModel.Endereco = fornecedorModel.Endereco.ToUpper().Trim();
            fornecedorModel.Telefone = fornecedorModel.Telefone.Trim();

            return fornecedorModel;
        }
        public static ProdutoModel FormataValoresProduto(ProdutoModel produtoModel)
        {
            produtoModel.Nome = produtoModel.Nome.ToUpper().Trim();
            produtoModel.Descricao = produtoModel.Descricao.ToUpper().Trim();

            return produtoModel;
        }
    }
}
