using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    public class PessoaModel
    {
        [Key] 
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Campo pode conter no maximo {0} caracteres")]
        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [MaxLength(80, ErrorMessage = "Campo pode conter no maximo {0} caracteres")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        //criar uma tabela de endereço
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe um ou mais numeros de telefone!", AllowEmptyStrings = false)]
        public string Telefone { get; set; }
    }
}
