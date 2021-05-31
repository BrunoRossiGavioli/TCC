using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Models
{
    public class EmailClienteModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }
    }
}
