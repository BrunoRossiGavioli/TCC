﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    [Table("Cliente")]
    public class ClienteModel : PessoaModel
    {
        [Key]
        public int ClienteId { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        public EnderecoModel Endereco { get; set; }

    }
}