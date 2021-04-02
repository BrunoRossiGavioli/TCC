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

        [MaxLength(50)]         
        public string Nome { get; set; }

        [MaxLength(80)]       
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        //criar uma tabela de endereço       
        public string Endereco { get; set; }
       
        public string Telefone { get; set; }
    }
}
