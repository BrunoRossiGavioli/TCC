using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Validacao.Formatacao
{
    public class FormataValores
    {
        public static VendedorModel FormataValoresVendedor(VendedorModel vendedor)
        {
            vendedor.Nome = vendedor.Nome.ToUpper().Trim();
            vendedor.Cpf = vendedor.Cpf.Trim();
            vendedor.Telefone = vendedor.Telefone?.Trim();
            vendedor.Email = vendedor.Email.Trim();
            vendedor.Senha = SecurityService.Criptografar(vendedor.Senha);
            return vendedor;
        }
        public static FornecedorEnderecoViewModel FormataValoresFornecedorView(FornecedorEnderecoViewModel fornecedor)
        {
            fornecedor.NomeFantasia = fornecedor.NomeFantasia.ToUpper().Trim();
            fornecedor.RazaoSocial = fornecedor.RazaoSocial.ToUpper().Trim();
            fornecedor.Logradouro = fornecedor.Logradouro.ToUpper().Trim();
            fornecedor.Localidade = fornecedor.Localidade.ToUpper().Trim();
            fornecedor.Complemento = fornecedor.Complemento.ToUpper().Trim();
            fornecedor.Bairro = fornecedor.Bairro.ToUpper().Trim();
            return fornecedor;
        }
        public static ProdutoModel FormataProduto(ProdutoModel prod)
        {
            prod.Nome = prod.Nome.ToUpper().Trim();
            return prod;
        }

        public static ClienteViewModel FormataCliente(ClienteViewModel cli)
        {
            cli.Nome = cli.Nome.Trim().ToUpper();
            cli.Telefone = cli.Telefone.Trim().ToUpper();
            cli.Cep = cli.Cep.Trim().ToUpper();
            cli.Bairro = cli.Bairro.Trim().ToUpper();
            cli.Complemento = cli.Complemento.Trim().ToUpper();
            cli.Cpf = cli.Cpf != null? cli.Cpf.Trim().ToUpper():cli.Cpf;
            cli.Email = cli.Email != null ? cli.Email = cli.Email.Trim() : cli.Email;
            cli.Localidade = cli.Localidade.Trim().ToUpper();
            cli.Logradouro = cli.Logradouro.Trim().ToUpper();
            return cli;
        }
    }
}
