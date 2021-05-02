using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [StringLength(14)]
        public string Cpf { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe o Email!")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [ScaffoldColumn(false)]
        public ClienteEnderecoModel Endereco { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

    }
}
