using System;
using System.ComponentModel.DataAnnotations;
using TCCESTOQUE.Models.Enum;

namespace TCCESTOQUE.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid VendedorId { get; set; }
        public Guid FornecedorId { get; set; }
        [Required(ErrorMessage = "Insira o Nome", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Insira o Custo", AllowEmptyStrings = false)]
        public decimal Custo { get; set; }
        [Required(ErrorMessage = "Insira o Valor", AllowEmptyStrings = false)]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Insira a Quantidade", AllowEmptyStrings = false)]

        public double Quantidade { get; set; }
        [Required(ErrorMessage = "Insira a Unidade de Medida", AllowEmptyStrings = false)]
        public UnidadeDeMedidaEnum UnidadeMedida { get; set; }
    }
}
