using System.ComponentModel.DataAnnotations;

namespace TCCESTOQUE.Models
{
    public class PessoaModel
    {
        [MaxLength(80)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
