using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    public class EnderecoModel
    {
        [Key]
        public int Id{ get; set; }

        [StringLength(8, ErrorMessage = "Cep tem que ter 8 caracteres")]
        [Required(ErrorMessage = "Informe o Cep", AllowEmptyStrings = false)]
        public string Cep { get; set; }

        [MaxLength(80, ErrorMessage = "O Campo excedeu o numero maximo de caracteres")]
        [Required(ErrorMessage = "Informe o Logradouro", AllowEmptyStrings = false)]
        public string Logradouro { get; set; }

        [MaxLength(80, ErrorMessage = "O Campo excedeu o numero maximo de caracteres")]
        public string Complemento { get; set; }

        [MaxLength(10, ErrorMessage = "O campo excedeu o numero maximo de caracteres")]
        public int Numero { get; set; }

        [MaxLength(80, ErrorMessage = "O Campo excedeu o numero maximo de caracteres")]
        [Required(ErrorMessage = "Informe o Bairro", AllowEmptyStrings = false)]
        public string Bairro { get; set; }

        [MaxLength(80, ErrorMessage = "O Campo excedeu o numero maximo de caracteres")]
        [Required(ErrorMessage = "Informe a Localidade", AllowEmptyStrings = false)]
        public string Localidade { get; set; }

        [StringLength(2, ErrorMessage = "O Campo deve ter {0} caracteres")]
        [Required(ErrorMessage = "Informe a Unidade Federativa", AllowEmptyStrings = false)]
        public string Uf { get; set; }
    }
}
