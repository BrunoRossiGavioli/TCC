using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.ViewModel.EditViewModels
{
    public class ProdutoEditViewModel
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }

        public int FornecedorId { get; set; }
    }
}
