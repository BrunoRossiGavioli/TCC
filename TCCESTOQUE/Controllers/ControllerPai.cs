using Microsoft.AspNetCore.Mvc;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.Controllers
{
    public class ControllerPai : Controller
    {
        internal void Autenticar()
        {
            var autenticacao = SecurityService.Autenticado(HttpContext);
            ViewBag.usuario = autenticacao == "" ? "Não Logado" : autenticacao;
            ViewBag.autenticado = autenticacao == "" ? false : true;
        }
    }
}
