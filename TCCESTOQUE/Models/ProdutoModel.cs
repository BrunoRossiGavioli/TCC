using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Custo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorUnitario { get; set; }

        public int Quantidade { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataEntrada { get; set; } = DateTime.Today;

        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; }
        [ScaffoldColumn(false)]
        public FornecedorModel Fornecedor { get; set; }




    }

}
