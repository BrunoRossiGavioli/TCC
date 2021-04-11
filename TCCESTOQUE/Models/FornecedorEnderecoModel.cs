using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
