namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensErroFornecedor
    {
        #region Erros de Campos Nulos
        public static string RazaoSocialVazia = "O campo Razão Social não pode ser nulo!";
        public static string NomeFantasiaVazio = "O campo Nome Fantasia não pode ser nulo!";
        public static string ProdutoVazio = "Insira um produto!";
        public static string CnpjVazio = "O campo Cnpj não pode ser nulo!";
        #endregion

        #region Erros ao exeder o tamanho maximo de um campo
        public static string NomeFantasiaTamanhoMaximo = "O campo Nome Fantasia excedeu o máximo de caracteres!";
        public static string RazaoSocialTamanhoMaximo = "O campo Razão Social tem que ter no mínimo 3 caracteres!";
        #endregion

        #region Já cadastrado
        public static string CnpjJaCadastrado = "O CNPJ já encontra-se cadastrado!";
        public static string RazaoSocialJaCadastrada = "A Razão Social já encontra-se cadastrado!";
        public static string NomeFantasiajaCadastrado = "O Nome Fantasia já encontra-se cadastrado!";
        #endregion

        #region Erros ao não alcançar o mínimo de caracteres        
        public static string NomeFantasiaTamanhoMinimo = "O campo Nome Fantasia tem que ter no mínimo 3 caracteres!";
        public static string RazaoSocialTamanhoMinimo = "O campo Razao Social tem que ter no mínimo 3 caracteres!";
        #endregion

        #region Tamanho obrigatorio
        public static string CnpjTamanho = "O campo Cnpj deve ter 18 caracteres!";
        #endregion
    }
}
