using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("Vendedor")] 
    public class VendedorModel : PessoaModel
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendedorId { get; set; }

        [MaxLength(50, ErrorMessage = "Campo pode conter no maximo {0} caracteres")]
        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha!", AllowEmptyStrings = false)]
        [MaxLength(70, ErrorMessage ="A senha pode ter no maximo {0}")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        [MaxLength(11, ErrorMessage = "O cpf deve ter no maximo {0}")]
        [Required(ErrorMessage = "Informe o cpf", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
        
        [ScaffoldColumn(false)]
        public bool Logado { get; set; }
    }
}
