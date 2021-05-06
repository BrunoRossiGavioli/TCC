using System.ComponentModel.DataAnnotations;

namespace TCCESTOQUE.Models
{
    public class EnderecoModel
    {
        [Key]
        public int EnderecoId { get; set; }

        [StringLength(9)]
        [Required(ErrorMessage = "Informe o Cep", AllowEmptyStrings = false)]
        public string Cep { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe o Logradouro", AllowEmptyStrings = false)]
        public string Logradouro { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe o Logradouro", AllowEmptyStrings = false)]
        public string Complemento { get; set; }

        [MaxLength(6)]
        [Required(ErrorMessage = "Informe o Número", AllowEmptyStrings = false)]
        public int Numero { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe o Bairro", AllowEmptyStrings = false)]
        public string Bairro { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe a Localidade", AllowEmptyStrings = false)]
        public string Localidade { get; set; }

        [StringLength(2, ErrorMessage = "O Campo deve ter {0} caracteres")]
        [Required(ErrorMessage = "Informe a Unidade Federativa", AllowEmptyStrings = false)]
        public string Uf { get; set; }
    }
}
