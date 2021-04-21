using Microsoft.AspNetCore.Mvc;
using System;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.Controllers
{
    public class ControllerPai : Controller
    {
        internal void Autenticar()
        {
            var autenticacao = SecurityService.Autenticado(HttpContext);
            ViewBag.usuario = autenticacao == null ? "Não Logado" : autenticacao.Usuario;
            ViewBag.emailHome = autenticacao == null ? "Não Logado" : autenticacao.Email;
            ViewBag.usuarioId = autenticacao == null ? 000 : autenticacao.VendedorId;
            ViewBag.autenticado = autenticacao == null ? false : true;
        }
    }
}
