using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    public class VendaModel
    {
        [Key]
        public int VendaId { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data de venda é obrigatoria!", AllowEmptyStrings = false)]
        public DateTime DataVenda { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        [ScaffoldColumn(false)]
        public VendedorModel Vendedor { get; set; }
        
        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Informe o Nome do cliente", AllowEmptyStrings = false)]
        public int ClienteId { get; set; }
        [ScaffoldColumn(false)]
        public ClienteModel Cliente { get; set; }

        public ICollection<VendaItensModel> Itens { get; set; }
    }
}
