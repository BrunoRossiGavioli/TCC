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
       
        [MaxLength(70)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; } 

        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
        
        [ScaffoldColumn(false)]
        public bool Logado { get; set; }
    }
}
