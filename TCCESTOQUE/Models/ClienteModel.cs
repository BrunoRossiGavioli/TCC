using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Cliente")]
    public class ClienteModel : PessoaModel
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o Nome", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [StringLength(14)]
        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Informe Endereço", AllowEmptyStrings = false)]
        public ClienteEnderecoModel Endereco { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

    }
}
