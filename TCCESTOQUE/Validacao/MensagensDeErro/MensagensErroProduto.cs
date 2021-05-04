namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensErroProduto
    {
        #region Valores Nulos
        public static string NomeVazio = "O campo Nome do produto não pode ser nulo !";
        public static string DescricaoVazia = "A campo Descrição  não pode ser nula !";
        public static string CustoVazio = "O campo Custo não pode ser nulo !";
        public static string ValorUnitarioVazio = "O campo Valor Unitario  não pode ser nulo !";
        public static string QuantidadeVazia = "A campo Quantidade  não pode ser nula !";
        public static string DataEntradaVazia = "A campo Data de Entrada não pode ser nulo !";
        public static string FornecedorVazio = "O campo Fornecedor não pode ser nulo !";
        #endregion

        #region Tamanho maximo        
        public static string NomeTamanhoMaximo = "O campo Nome excedeu o máximo de caracteres !";
        public static string DescricaoTamanhoMaximo = "O campo Descrição excedeu o máximo de caracteres !";
        #endregion
        //

        #region Tamanho minimo
        public static string NomeTamanhoMinimo = "O campo Nome tem que ter no mínimo {0} caracteres !";
        public static string DescricaoTamanhoMinimo = "O campo Nome tem que ter no mínimo {0} caracteres !";
        public static string DataDeEntradaFutura = "O campo Nome tem que ter no mínimo {0} caracteres !";
        public static string CustoMinimo = "O campo Custo tem que ter no mínimo {0} caracteres !";
        public static string ValorUnitarioMinimo = "O campo Valor Unitário tem que ter no mínimo {0} caracteres !";
        public static string QuantidadeMinima = "O campo Quantidade tem que ter no mínimo {0} caracteres !";
        #endregion

    }
}
