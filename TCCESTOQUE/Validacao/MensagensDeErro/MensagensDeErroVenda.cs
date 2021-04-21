using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensDeErroVenda
    {
        #region Campos Nulos
        public static string ClienteVazio = "O Campo Cliente não pode ser nulo !";
        public static string VendedorVazio = "O Campo Vendedor não pode ser nulo !";
        public static string ProdutoVazio = "O Campo Produto não pode ser nulo !";
        public static string DataVazia = "O Campo Data não pode ser nulo !";
        public static string ValorVazio = "O Campo Valor não pode ser nulo !";
        public static string QuantidadeVazia = "O Campo Quantidade não pode ser nulo !";
        #endregion

        #region Campos tamanho mínimo
        public static string ClienteTamanhoMinimo = "O Campo Cliente tem que ter no mínimo 3 caracteres !";
        public static string VendedorTamanhoMinimo = "O Campo Vendedor tem que ter no mínimo 3 caracteres !";
        public static string ProdutoTamanhoMinimo = "O Campo Produto tem que ter no mínimo 3 caracteres !";
        public static string ValorTamanhoMinimo = "O Campo Valor tem que ser maior que 0 !";
        public static string QuantidadeTamanhoMinimo = "O Quantidade Cliente tem que ser maior que 0 !";
        #endregion
    }
}
