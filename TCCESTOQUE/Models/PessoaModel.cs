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
        [MaxLength(80, ErrorMessage = "Campo pode conter no maximo {0} caracteres")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe um ou mais numeros de telefone!", AllowEmptyStrings = false)]
        public string Telefone { get; set; }
    }
}
