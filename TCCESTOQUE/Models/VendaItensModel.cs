using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("VendaItens")]
    public class VendaItensModel
    {
        [Key]
        public int VendaItensId { get; set; }

        [ForeignKey("Venda")]
        public int? VendaId { get; set; }
        public VendaModel Venda { get; set; }

        [ForeignKey("Carrinho")]
        [ScaffoldColumn(false)]
        public int? CarrinhoId { get; set; }
        [ScaffoldColumn(false)]
        public CarrinhoModel Carrinho { get; set; }

        [ForeignKey("Vendedor")]
        [ScaffoldColumn(false)]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        [Required(ErrorMessage = "Informe a quantidade!")]
        public int Quantidade { get; set; }

    }
}
