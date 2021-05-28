using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models.Enum;

namespace TCCESTOQUE.ViewModel
{
    public class ProdutoViewModel
    {
        public Guid VendedorId { get; set; }
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal Valor { get; set; }
        public double Quantidade { get; set; }
        public UnidadeDeMedidaEnum UnidadeMedida { get; set; }
    }
}
