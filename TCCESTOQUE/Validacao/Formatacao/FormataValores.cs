using System;

namespace TCCESTOQUE.Validacao.Formatacao
{
    public class FormataValores
    {
        public static string FormataMaiusculo(string caracteres)
        {
            return caracteres = caracteres.ToUpper().Trim();
        }

        public static string FormataMinusculo(string caracteres)
        {
            return caracteres = caracteres.ToLower().Trim();
        }
    }
}
