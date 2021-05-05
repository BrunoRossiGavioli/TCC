using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("ClienteEndereco")]
    public class ClienteEnderecoModel : EnderecoModel
    {
        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }

        public ClienteModel Cliente { get; set; }

    }
}
