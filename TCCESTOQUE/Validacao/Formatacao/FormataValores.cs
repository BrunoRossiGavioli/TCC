using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Validacao.Formatacao
{
    public class FormataValores
    {
        public static VendedorModel FormataValoresVendedor(VendedorModel vendedor)
        {
            vendedor.Nome = vendedor.Nome.ToUpper().Trim();
            vendedor.Email = vendedor.Email.Trim();
            vendedor.Senha = SecurityService.Criptografar(vendedor.Senha);
            return vendedor;
        }
        public static VendedorEditViewModel FormataValoresVendedorEdit(VendedorEditViewModel vendedor)
        {
            vendedor.Nome = vendedor.Nome.ToUpper().Trim();
            vendedor.Email = vendedor.Email.Trim();
            vendedor.Senha = SecurityService.Criptografar(vendedor.Senha);
            return vendedor;
        }
        public static FornecedorEnderecoViewModel FormataValoresFornecedorView(FornecedorEnderecoViewModel fornecedor)
        {
            fornecedor.NomeFantasia = fornecedor.NomeFantasia != null ? fornecedor.NomeFantasia.ToUpper().Trim() : fornecedor.NomeFantasia;
            fornecedor.RazaoSocial = fornecedor.RazaoSocial.ToUpper().Trim();
            fornecedor.Logradouro = fornecedor.Logradouro != null ? fornecedor.Logradouro.ToUpper().Trim() : fornecedor.Logradouro;
            fornecedor.Localidade = fornecedor.Localidade.ToUpper().Trim();
            fornecedor.Complemento = fornecedor.Complemento != null ? fornecedor.Complemento.ToUpper().Trim() : fornecedor.Complemento;
            fornecedor.Bairro = fornecedor.Bairro != null ? fornecedor.Bairro.ToUpper().Trim() : fornecedor.Bairro;
            return fornecedor;
        }

        public static ClienteViewModel FormataValoresClienteView(ClienteViewModel cli)
        {
            cli.Logradouro = cli.Logradouro != null ? cli.Logradouro.ToUpper().Trim() : cli.Logradouro;
            cli.Localidade = cli.Localidade.ToUpper().Trim();
            cli.Complemento = cli.Complemento != null ? cli.Complemento.ToUpper().Trim() : cli.Complemento;
            cli.Bairro = cli.Bairro != null ? cli.Bairro.ToUpper().Trim() : cli.Bairro;
            cli.Email = cli.Email != null ? cli.Email.Trim() : cli.Email;
            cli.Nome = cli.Nome.ToUpper().Trim();
            return cli;
        }
        public static ProdutoModel FormataValoresProdutoModel(ProdutoModel prod)
        {
            prod.Nome = prod.Nome.Trim().ToUpper();
            prod.Descricao = prod.Descricao != null ? prod.Descricao.ToLower().Trim() : prod.Descricao;
            return prod;
        }
    }
}
