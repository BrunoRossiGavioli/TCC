using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("FornecedorEndereco")]
    public class FornecedorEnderecoModel : EnderecoModel
    {
        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }

        [ScaffoldColumn(false)]
        public FornecedorModel Fornecedor { get; set; }
    }
}
