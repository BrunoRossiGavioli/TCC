using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    public class VendaItensModel
    {
        [Key]
        public int VendaItensId { get; set; }

        [ForeignKey("Venda")]
        public int VendaId { get; set; }
        public VendaModel Venda { get; set; }


        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        [Required(ErrorMessage = "Informe a quantidade!")]
        public int Quantidade { get; set; }

    }
}
