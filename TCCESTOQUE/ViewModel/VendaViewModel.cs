using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.ViewModel
{
    public class VendaViewModel
    {
        public decimal Valor { get; set; }
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }

        public Guid ProdutoId { get; set; }
        public Guid VendedorId { get; set; }
        public Guid ClienteId { get; set; }
    }
}
