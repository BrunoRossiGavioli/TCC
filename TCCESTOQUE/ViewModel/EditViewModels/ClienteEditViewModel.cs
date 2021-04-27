using TCCESTOQUE.Models;

namespace TCCESTOQUE.ViewModel.EditViewModels
{
    public class ClienteEditViewModel : PessoaModel
    {
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
    }
}
