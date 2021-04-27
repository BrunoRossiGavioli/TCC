using System.ComponentModel.DataAnnotations;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.ViewModel.EditViewModels
{
    public class VendedorEditViewModel : PessoaModel
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha!", AllowEmptyStrings = false)]
        [MaxLength(70)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }

    }
}
