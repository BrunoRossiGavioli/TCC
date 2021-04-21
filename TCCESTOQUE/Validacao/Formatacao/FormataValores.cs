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
            vendedor.Email = vendedor.Email.Trim();
            vendedor.Senha = SecurityService.Criptografar(vendedor.Senha);
            return vendedor;
        }
        public static FornecedorEnderecoViewModel FormataValoresFornecedorView(FornecedorEnderecoViewModel fornecedor)
        {
            fornecedor.NomeFantasia = fornecedor.NomeFantasia != null? fornecedor.NomeFantasia.ToUpper().Trim() : fornecedor.NomeFantasia;
            fornecedor.RazaoSocial = fornecedor.RazaoSocial.ToUpper().Trim();
            fornecedor.Logradouro = fornecedor.Logradouro != null? fornecedor.Logradouro.ToUpper().Trim(): fornecedor.Logradouro;
            fornecedor.Localidade = fornecedor.Localidade.ToUpper().Trim();
            fornecedor.Complemento = fornecedor.Complemento != null? fornecedor.Complemento.ToUpper().Trim(): fornecedor.Complemento;
            fornecedor.Bairro = fornecedor.Bairro != null? fornecedor.Bairro.ToUpper().Trim(): fornecedor.Bairro;
            return fornecedor;
        }
    }
}
