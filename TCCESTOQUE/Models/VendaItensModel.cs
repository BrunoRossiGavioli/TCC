using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("VendaItens")]
    public class VendaItensModel
    {
        [Key]
        public Guid VendaItensId { get; set; }

        [Required(ErrorMessage = "Informe a quantidade!")]
        public double Quantidade { get; set; }

        [Required]
        public decimal PrecoProduto { get { return Produto.ValorUnitario; } }

        [Required]
        public decimal CustoProduto { get { return Produto.Custo; } }

        [ForeignKey("Venda")]
        public int? VendaId { get; set; }
        public VendaModel Venda { get; set; }

        [ForeignKey("Carrinho")]
        [ScaffoldColumn(false)]
        public int? CarrinhoId { get; set; }
        public CarrinhoModel Carrinho { get; set; }

        [ForeignKey("Vendedor")]
        [ScaffoldColumn(false)]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }
    }
}
