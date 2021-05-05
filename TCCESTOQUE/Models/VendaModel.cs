using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Venda")]
    public class VendaModel
    {
        [Key]
<<<<<<< HEAD
        public Guid VendaId { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal Valor { get; set; }
=======
        public int VendaId { get; set; }    
>>>>>>> 2f52e926b313da0a5fe6427d67fd5779177e9a86

        [Required(ErrorMessage = "Data de venda é obrigatoria!", AllowEmptyStrings = false)]
        public DateTime DataVenda { get; set; }

        [ScaffoldColumn(false)]
        public bool Cancelada { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        [ScaffoldColumn(false)]
        public VendedorModel Vendedor { get; set; }
        
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        [ScaffoldColumn(false)]
        public ClienteModel Cliente { get; set; }

        public ICollection<VendaItensModel> Itens { get; set; }
    }
}
