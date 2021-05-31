using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.POCO
{
    public class AlterarSenha
    {
        public Guid VendedorId { get; set; }
        public Guid TrocaId { get; set; }
        public int Codigo { get; set; }
        public string NovaSenha { get; set; }
    }
}
