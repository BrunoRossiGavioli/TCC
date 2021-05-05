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
        public int ProdutoId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Required(ErrorMessage = "Informe o custo")]
        public decimal Custo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Required(ErrorMessage = "Informe o valor unitario")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "Informe a quantidade")]
        public double Quantidade { get; set; }

        
        public UnidadeDeMedidaEnum UnidadeDeMedida { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        //[ForeignKey("Fornecedor")]
        //public int FornecedorId { get; set; }
        //public FornecedorModel Fornecedor { get; set; }


        #region NavigationProperty
        [ScaffoldColumn(false)]
        public ICollection<VendaItensModel> Itens { get; set; }
        
        #endregion
    }

}
