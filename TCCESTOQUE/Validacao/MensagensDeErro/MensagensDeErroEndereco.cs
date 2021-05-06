namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensDeErroEndereco
    {
        #region Campos vazios
        public static string CepVazio = "O campo Cep não pode ser nulo !";
        public static string LogradouroVazio = "O campo Logradouro não pode ser nulo !";
        public static string ComplementoVazio = "O campo Complemento não pode ser nulo !";
        public static string NumeroVazio = "O campo Número não pode ser nulo !";
        public static string BairroVazio = "O campo Bairro não pode ser nulo !";
        public static string LocalidadeVazio = "O Localidade não pode ser nulo !";
        public static string UfVazio = "O campo Uf não pode ser nulo !";
        #endregion

        //

        #region tamanho máximo
        public static string CepTamanho = "O campo Cep tem que ter 9 digitos!";
        public static string LogradouroTamanhoMaximo = "O campo Logradouro excedeu o numero maximo de caracteres !";
        public static string ComplementoTamanhoMaximo = "O campo Complemento excedeu o numero maximo de caracteres!";
        public static string NumeroTamanhoMaximo = "O campo Número excedeu o numero maximo de caracteres !";
        public static string BairroTamanhoMaximo = "O campo Bairro excedeu o numero maximo de caracteres  !";
        public static string LocalidadeTamanhoMaximo = "O Localidade excedeu o numero maximo de caracteres  !";
        public static string UfTamanho = "O campo Uf deve ter 2 caracteres !";
        #endregion
        //

        #region tamanho mínimo
        public static string LogradouroTamanhoMinimo = "O campo Logradouro tem que ter no mínimo 3 caracteres!";
        public static string ComplementoTamanhoMinimo = "O campo Complemento tem que ter no mínimo 3 caracteres!";
        public static string NumeroTamanhoMinimo = "O campo Número tem ser maior ou igual a 1!";
        public static string BairroTamanhoMinimo = "O campo Bairro tem que ter no mínimo 2 caracteres !";
        public static string LocalidadeTamanhoMinimo = "O Localidade tem que ter no mínimo 3 caracteres !";
        #endregion
    }
}
