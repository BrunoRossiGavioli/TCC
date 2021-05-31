using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("AlterarSenha")]
    public class AlterarSenhaModel
    {
        [Key]
        public Guid Id { get; set; }

        public int Codigo { get; set; }

        public DateTime DataEmissão { get; set; }

        public bool Invalida { get; set; }

        [ForeignKey("Vendedor")]
        public Guid VendedorId { get; set; }

        public VendedorModel Vendedor { get; set; }
    }
}
