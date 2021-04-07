using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks; 

namespace TCCESTOQUE.Models
{
    [Table("Fornecedor")]
    public class FornecedorModel : PessoaModel
    {
        [MaxLength(50, ErrorMessage = "Nome fantasia deve possuir no maximo {0} caracteres!")]
        public string NomeFantasia { get; set; }

        [MaxLength(14, ErrorMessage = "O campo CNPJ deve possuir 14 caracteres!")]
        public string Cnpj { get; set; }

        [ScaffoldColumn(false)] 
        public ICollection<ProdutoModel> Produtos { get; set; } 

    }
}
