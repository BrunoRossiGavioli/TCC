namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensErroFornecedor
    {
        #region Erros de Campos Nulos
        public static string NomeVazio = "O campo Nome não pode ser nulo!";
        public static string RazaoSocialVazia = "O campo Razão Social não pode ser nulo!";
        public static string EmailVazio = "O campo Email não pode ser nulo!";
        public static string DataNascimentoVazia = "O campo Data de nascimento não pode ser nulo!";
        public static string EnderecoVazio = "O campo Endereço não pode ser nulo!";
        public static string TelefoneVazio = "O campo Telefone não pode ser nulo!";
        public static string NomeFantasiaVazio = "O campo Nome Fantasia não pode ser nulo!";
        public static string ProdutoVazio = "O campo Produto não pode ser vazio!";
        public static string CnpjVazio = "O campo Cnpj não pode ser nulo!";
        #endregion

        #region Erros ao exeder o tamanho maximo de um campo
        public static string NomeTamanhoMaximo = "O campo Nome excedeu o máximo de caracteres!";
        public static string EmailTamanhoMaximo = "O campo Email excedeu o máximo de caracteres!";
        public static string EnderecoTamanhoMaximo = "O campo Endereço excedeu o máximo de caracteres!";
        public static string DataNascimentoTamanhoMaximo = "O campo Data de Nascimento não pode ser futura!";
        public static string NomeFantasiaTamanhoMaximo = "O campo Nome Fantasia excedeu o máximo de caracteres!";
        public static string RazaoSocialTamanhoMaximo = "O campo Razão Social tem que ter no mínimo {0} caracteres!";
        public static string ProdutoTamanhoMaximo = "O campo Produto excedeu o máximo de caracteres!";
        //
        #endregion

        public static string EmailFormatoInvalido = "Email inválido!";
        public static string TelefoneTamanho = "O campo Telefone deve ter 11 caracteres!";
        public static string CnpjJaCadastrado = "O CNPJ já encontra-se cadastrado!";

        public static string RazaoSocialJaCadastrada = "A Razão Social já encontra-se cadastrado!";
        public static string NomeFantaziajaCadastrado = "O Nome Fantasia já encontra-se cadastrado!";
        public static string EmailJaCadastrado = "O Email já encontra-se cadastrado";

        #region Erros ao não alcançar o mínimo de caracteres        
        public static string NomeTamanhoMinimo = "O campo Nome tem que ter no mínimo {0} caracteres!";
        public static string EmailTamanhoMinimo = "O campo Email tem que ter no mínimo {0} caracteres!";
        public static string EnderecoTamanhoMinimo = "O campo Endereço tem que ter no mínimo {0} caracteres!";
        public static string DataTamanhoMinimo = "Você deve ter no mínimo 18 anos!";
        public static string ProdutoTamanhoMinimo = "O campo Produto tem que ter no mínimo {0} caracteres!";
        public static string NomeFantasiaTamanhoMinimo = "O campo Nome Fantasia tem que ter no mínimo {0} caracteres!";
        public static string RazaoSocialTamanhoMinimo = "O campo Razao Social tem que ter no mínimo {0} caracteres!";
        #endregion

        public static string CnpjTamanho = "O campo Cnpj deve ter 14 caracteres!";

    }
}
