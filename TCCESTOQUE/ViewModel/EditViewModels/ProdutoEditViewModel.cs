using System.ComponentModel.DataAnnotations.Schema;

namespace TCCESTOQUE.ViewModel.EditViewModels
{
    public class ProdutoEditViewModel
    {
        public int ProdutoId { get; set; }
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Custo { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorUnitario { get; set; }
        public int FornecedorId { get; set; }
    }
}
