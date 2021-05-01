using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Vendedor")]
    public class VendedorModel : PessoaModel
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendedorId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha!", AllowEmptyStrings = false)]
        [MaxLength(50)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Logado { get; set; }
    }
}
