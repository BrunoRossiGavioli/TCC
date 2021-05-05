using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCCESTOQUE.Models.Enum;

namespace TCCESTOQUE.Models
{
    [Table("Vendedor")] 
    public class VendedorModel
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VendedorId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [MaxLength(70)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Required(ErrorMessage = "Informe a senha!", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        [MaxLength(14)]
        [Required(ErrorMessage = "Informe o cpf", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe o Email!")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(14)]
        public string Telefone { get; set; }

        public SexoEnum Sexo { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
    }
}
