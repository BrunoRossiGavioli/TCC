using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Fornecedor")]
    public class FornecedorModel : PessoaModel
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ForncedorId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe a RazãoSocial de usuario", AllowEmptyStrings = false)]
        public string RazaoSocial { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe a RazãoSocial de usuario", AllowEmptyStrings = false)]
        public string NomeFantasia { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "Informe a RazãoSocial de usuario", AllowEmptyStrings = false)]
        public string Cnpj { get; set; }

        [ScaffoldColumn(false)]
        public FornecedorEnderecoModel Endereco { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<ProdutoModel> Produtos { get; set; }

    }
}
