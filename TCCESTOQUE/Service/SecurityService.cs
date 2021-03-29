using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
