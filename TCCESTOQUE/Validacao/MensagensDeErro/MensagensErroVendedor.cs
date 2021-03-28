using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensErroVendedor
    {
        #region Erros de Campos Nulos
        public static string NomeVazio ="O Nome não pode ser nulo";
        public static string SenhaVazia ="A Senha não pode ser nula";
        public static string EmailVazio  ="O Email não pode ser nulo";
        public static string DataNascimentoVazia ="A Data de nascimento não pode ser nulo";
        public static string EnderecoVazio ="O Endereço não pode ser nulo";
        public static string TelefoneVazio ="O Telefone não pode ser nulo";
        public static string CpfVazio ="O Cpf não pode ser nulo";
        #endregion

        #region Erros ao exeder o tamanho maximo de um campo
        public static string NomeTamanhoMaximo = "O Nome excedeu o máximo de caracteres";
        public static string SenhaTamanhoMaximo = "A Senha  excedeu o máximo de caracteres";
        public static string EmailTamanhoMaximo = "O Email  excedeu o máximo de caracteres";
        public static string EnderecoTamanhoMaximo = "O Endereço  excedeu o máximo de caracteres";
        public static string TelefoneTamanhoMaximo = "O Telefone  excedeu o máximo de caracteres";
        public static string CpfTamanhoMaximo = "O CPF  excedeu o máximo de caracteres";
        public static string DataNascimentoTamanhoMaximo = "A Data de Nascimento não pode ser futura"; 
        #endregion

        #region Erros ao não alcançar o mínimo de caracteres
        public static string NomeTamanhoMinimo = "O Nome tem que ter no mínimo {0} caracteres";
        public static string SenhaTamanhoMinimo = "A Seha tem que ter no mínimo {0} caracteres";
        public static string EmailTamanhoMinimo = "O Email tem que ter no mínimo {0} caracteres";
        public static string EnderecoTamanhoMinimo = "O Endereço tem que ter no mínimo {0} caracteres";
        public static string TelefoneTamanhoMinimo = "O Telefone tem que ter no mínimo {0} caracteres";
        public static string CpfTamanhoMinimo = "O CPF tem que ter no mínimo {0} caracteres";
        public static string DataTamanhoMinimo = "Você deve ter no mínimo 18 anos";
        #endregion
    }
}