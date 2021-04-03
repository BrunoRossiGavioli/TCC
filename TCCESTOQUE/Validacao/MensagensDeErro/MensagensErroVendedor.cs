using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MensagensErroVendedor
    {
        #region Erros de Campos Nulos
        public static string NomeVazio ="O campo Nome não pode ser nulo!";
        public static string SenhaVazia ="O campo Senha não pode ser nula!";
        public static string EmailVazio  ="O campo Email não pode ser nulo!";
        public static string DataNascimentoVazia ="O campo Data de nascimento não pode ser nulo!";
        public static string EnderecoVazio ="O campo Endereço não pode ser nulo!";
        public static string TelefoneVazio ="O campo Telefone não pode ser nulo!";
        public static string CpfVazio ="O campo Cpf não pode ser nulo!";
        #endregion

        #region Erros ao exeder o tamanho maximo de um campo
        public static string NomeTamanhoMaximo = "O campo Nome excedeu o máximo de caracteres!";
        public static string SenhaTamanhoMaximo = "O campo Senha excedeu o máximo de caracteres!";
        public static string EmailTamanhoMaximo = "O campo Email excedeu o máximo de caracteres!";
        public static string EnderecoTamanhoMaximo = "O campo Endereço excedeu o máximo de caracteres!";        
        public static string DataNascimentoTamanhoMaximo = "O campo Data de Nascimento não pode ser futura!"; 
        #endregion

        public static string EmailFormatoInvalido = "Email inválido, tente novamente!";
        public static string TelefoneTamanho = "O campo Telefone deve ter 11 caracteres!";
        public static string CpfTamanho = "O campo CPF deve ter 11 caracteres!";
        
        #region Erros ao não alcançar o mínimo de caracteres        
        public static string NomeTamanhoMinimo = "O campo Nome tem que ter no mínimo {0} caracteres!";
        public static string SenhaTamanhoMinimo = "O campo Seha tem que ter no mínimo {0} caracteres!";
        public static string EmailTamanhoMinimo = "O campo Email tem que ter no mínimo {0} caracteres!";        
        public static string EnderecoTamanhoMinimo = "O campo Endereço tem que ter no mínimo {0} caracteres!";
        public static string DataTamanhoMinimo = "Você deve ter no mínimo 18 anos!";       
        #endregion
    }
}
