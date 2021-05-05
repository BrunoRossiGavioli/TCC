using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        public Guid ProdutoId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Required(ErrorMessage = "Informe o custo")]
        public decimal Custo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Required(ErrorMessage = "Informe o valor unitario")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "Informe a quantidade")]
        public int Quantidade { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<VendaItensModel> Itens { get; set; }

        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }
        public FornecedorModel Fornecedor { get; set; }

        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }


    }

}
