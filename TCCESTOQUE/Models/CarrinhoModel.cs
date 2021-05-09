﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("Carrinho")]
    public class CarrinhoModel
    {
        [Key]
        public Guid CarrinhoId { get; set; }

        [ForeignKey("Vendedor")]
        public Guid VendedorId { get; set; }
        public VendedorModel Vendedor { get; set; }

        [NotMapped]
        public Guid ClienteId { get; set; }
        
        [NotMapped]
        public ClienteModel Cliente { get; set; }

        public ICollection<VendaItensModel> Itens { get; set; }
    }
}