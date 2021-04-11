using System.ComponentModel.DataAnnotations;

namespace TCCESTOQUE.Models
{
    public class PessoaModel
    {
        [MaxLength(80)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe um ou mais numeros de telefone!", AllowEmptyStrings = false)]
        public string Telefone { get; set; }
    }
}
