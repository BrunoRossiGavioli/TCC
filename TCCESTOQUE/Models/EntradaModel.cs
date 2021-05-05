using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("Entrada")]
    public class EntradaModel
    {
        [Key]
        public Guid EntradaId { get; set; }

        [Required]
        public decimal PrecoProduto { get { return Produto.ValorUnitario; } }

        [Required]
        public decimal CustoProduto { get { return Produto.Custo; } }

        [Required]
        public double QuantidadeProduto { get; set; }

        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        [ForeignKey("Fornecedor")]
        public Guid FornecedorId { get; set; }
        public FornecedorModel Fornecedor { get; set; }

        [ForeignKey("Vendedor")]
        public Guid VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }
    }
}
