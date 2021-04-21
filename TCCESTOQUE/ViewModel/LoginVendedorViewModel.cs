﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.ViewModel
{
    public class LoginVendedorViewModel
    {
        public int VendedorId { get; set; }

        [MaxLength(80)]
        [Required(ErrorMessage = "Informe O Email!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha!", AllowEmptyStrings = false)]
        [MaxLength(70)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }
    }
}
