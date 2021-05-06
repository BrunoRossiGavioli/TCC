namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensErroVendedor
    {
        #region Erros de Campos Nulos
        public static string NomeVazio = "O Nome não pode ser nulo!";
        public static string SenhaVazia = "A Senha não pode ser nula!";
        public static string EmailVazio = "O Email não pode ser nulo!";
        public static string DataNascimentoVazia = "A Data de nascimento não pode ser nula!";
        public static string EnderecoVazio = "O Endereço não pode ser nulo!";
        public static string TelefoneVazio = "O Telefone não pode ser nulo!";
        public static string CpfVazio = "O Cpf não pode ser nulo!";
        #endregion

        #region Erros ao exeder o tamanho maximo de um campo
        public static string NomeTamanhoMaximo = "O Nome excedeu o máximo de caracteres!";
        public static string SenhaTamanhoMaximo = "A Senha excedeu o máximo de caracteres!";
        public static string EmailTamanhoMaximo = "O Email excedeu o máximo de caracteres!";
        public static string EnderecoTamanhoMaximo = "O Endereço excedeu o máximo de caracteres!";
        public static string DataNascimentoTamanhoMaximo = "A Data de Nascimento não pode ser futura!";
        #endregion

        public static string EmailFormatoInvalido = "Email inválido!";
        public static string TelefoneTamanho = "O Telefone deve ter 11 digitos!";
        public static string CpfTamanho = "O CPF deve ter 11 digitos!";
        public static string CpfjaCadastrado = "O CPF ja encontra-se cadastrado";
        public static string EmailNaoEncontrado = "Email não encontrado!";

        public static string SenhaIncorreta = "Senha incorreta!";


        public static string TelefoneJaCadastrado = "O Telefone ja encontra-se cadastrado";
        public static string EmailJaCadastrado = "O Email ja encontra-se cadastrado";
        #region Erros ao não alcançar o mínimo de caracteres        
        public static string NomeTamanhoMinimo = "O Nome tem que ter no mínimo 3 caracteres!";
        public static string SenhaTamanhoMinimo = "A Seha tem que ter no mínimo 8 caracteres!";
        public static string EmailTamanhoMinimo = "O Email tem que ter no mínimo 7 caracteres!";
        public static string EnderecoTamanhoMinimo = "O Endereço tem que ter no mínimo 3 caracteres!";
        public static string DataTamanhoMinimo = "Você deve ter no mínimo 18 anos!";
        #endregion
    }
}
