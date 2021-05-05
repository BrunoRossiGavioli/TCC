using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("Carrinho")]
    public class CarrinhoModel
    {
        [Key]
        public int CarrinhoId { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Valor { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

        [NotMapped]
        public int ClienteId { get; set; }
        
        [NotMapped]
        public ClienteModel Cliente { get; set; }

        public ICollection<VendaItensModel> Itens { get; set; }
    }
}
