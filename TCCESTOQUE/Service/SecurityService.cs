using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace TCCESTOQUE.Service
{
    public static class SecurityService
    {
        public static string Autenticado(HttpContext context)
        {
            var usuario = "";
            if (context.User.Identity.IsAuthenticated)
                usuario = context.User.Identity.Name;

            return usuario;
        }

        public static string Criptografar(string senha)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(senha));

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
