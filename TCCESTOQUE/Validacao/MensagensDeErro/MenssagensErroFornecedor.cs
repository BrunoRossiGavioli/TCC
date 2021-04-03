using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCCESTOQUE.Validacao.MensagensDeErro
{
    public static class MenssagensErroFornecedor
    {
      #region Erros de Campos Nulos
        public static string NomeVazio ="O Nome não pode ser nulo!";
        public static string EmailVazio  ="O Email não pode ser nulo!";
        public static string DataNascimentoVazia ="A Data de nascimento não pode ser nulo!";
        public static string EnderecoVazio ="O Endereço não pode ser nulo!";
        public static string TelefoneVazio ="O Telefone não pode ser nulo!";
        #endregion

        #region Erros ao exeder o tamanho maximo de um campo
        public static string NomeTamanhoMaximo = "O Nome excedeu o máximo de caracteres!";
        public static string EmailTamanhoMaximo = "O Email excedeu o máximo de caracteres!";
        public static string EnderecoTamanhoMaximo = "O Endereço excedeu o máximo de caracteres!";        
        public static string DataNascimentoTamanhoMaximo = "A Data de Nascimento não pode ser futura!"; 
        #endregion

        public static string EmailFormatoInvalido = "Email inválido, tente novamente!";
        public static string TelefoneTamanho = "O Telefone deve ter 11 caracteres!";
        
        #region Erros ao não alcançar o mínimo de caracteres        
        public static string NomeTamanhoMinimo = "O Nome tem que ter no mínimo {0} caracteres!";
        public static string EmailTamanhoMinimo = "O Email tem que ter no mínimo {0} caracteres!";        
        public static string EnderecoTamanhoMinimo = "O Endereço tem que ter no mínimo {0} caracteres!";
        public static string DataTamanhoMinimo = "Você deve ter no mínimo 18 anos!";       
        #endregion

        public static string NomeFantasiaVazio ="O Nome Fantasia não pode ser nulo!";
        public static string NomeFantasiaTamanhoMaximo ="O Nome Fantasia excedeu o máximo de caracteres!";  
        public static string NomeFantasiaTamanhoMinimo ="O Nome Fantasia tem que ter no mínimo {0} caracteres!";

        public static string CnpjVazio ="O Cnpj não pode ser nulo!";             
        public static string CnpjTamanho = "O Cnpj deve ter 14 caracteres!";     

        public static string ProdutoVazio = "O Produto não pode ser vazio!";
        public static string ProdutoTamanhoMaximo = "O Produto excedeu o máximo de caracteres!";
        public static string ProdutoTamanhoMinimo = "O Produto tem que ter no mínimo {0} caracteres!";
    }
}
