using System;

namespace TCCESTOQUE.ViewModel
{
    public class VendaViewModel
    {
        public decimal Valor { get; set; }
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }

        public int ProdutoId { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
    }
}
