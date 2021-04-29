using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Fornecedor")]
    public class FornecedorModel : BaseModel
    {
        
        [MaxLength(50)]
        [Required(ErrorMessage = "Informe a RazãoSocial de usuario", AllowEmptyStrings = false)]
        public string RazaoSocial { get; set; }

        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "Informe a RazãoSocial de usuario", AllowEmptyStrings = false)]
        public string Cnpj { get; set; }

        [ScaffoldColumn(false)]
        public FornecedorEnderecoModel Endereco { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<ProdutoModel> Produtos { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

        [MaxLength(80)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
