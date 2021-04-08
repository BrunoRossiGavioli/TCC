using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.ViewModel
{
    public class ForncedorEnderecoViewModel
    {
        #region Fornecedor
        public int FornecedorId { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        #endregion

        #region Endereco
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        #endregion
    }
}
