using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.ViewModel.EditViewModels
{
    public class VendedorEditViewModel
    {
        public int VendedorId { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o nome de usuario", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha!", AllowEmptyStrings = false)]
        [MaxLength(70)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }

    }
}
