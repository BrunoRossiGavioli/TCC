using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    public class VendaItensModel : BaseModel
    {
        
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
