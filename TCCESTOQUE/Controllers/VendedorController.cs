using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Controllers
{
    public class VendedorController : ControllerPai
    {
        private readonly IVendedorService _vendedorService;

        public VendedorController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        public IActionResult Index()
        {
            Autenticar();
            return View(_vendedorService.GetCriacao());
        }

        // GET: Vendedor/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            Autenticar();
            return View(_vendedorService.GetDetalhes(id));
        }

        // GET: Vendedor/Create
        public IActionResult Create()
        {
            Autenticar();
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Senha,Cpf,Nome,Email,DataNascimento,Endereco,Telefone")] VendedorModel vendedorModel)
        {
            Autenticar();
            var res = _vendedorService.PostCriacao(vendedorModel);
            if (res)
                return RedirectToAction("Index", "Home");

            return View(vendedorModel);
        }

        // GET: Vendedor/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            return View(_vendedorService.GetEdicao(id));
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, [Bind("VendedorId,Nome,Email,Senha,Telefone")] VendedorEditViewModel vendedorModel)
        {
            Autenticar();
            var res = _vendedorService.PutEdicao(id, vendedorModel);
            if (res)
                return RedirectToAction("Index", "Home");

            return View(vendedorModel);
        }

        // GET: Vendedor/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Autenticar();
            return View(_vendedorService.GetExclusao(id));
        }

        // POST: Vendedor/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _vendedorService.PostExclusao(id);
            return RedirectToAction("Index", "Home");
        }

        // GET
        public IActionResult Login()
        {
            Autenticar();
            return View();
        }

        //POST
        [HttpPost, ActionName("Login")]
        public IActionResult Login(LoginVendedorViewModel vendedor)
        {
            Autenticar();
            var res = _vendedorService.PostLogin(vendedor);
            var getEmail = _vendedorService.GetEmail(vendedor.Email);
            var getSenha = _vendedorService.GetSenha(vendedor.Senha);
            if (res != null)
            {
                HttpContext.SignInAsync(res);
                return RedirectToAction("Index", "Home");
            }
            return View(vendedor);
        }

        //GET
        [Authorize]
        public IActionResult Logout()
        {
            Autenticar();
            return View();
        }

        //POST
        [Authorize]
        [HttpPost, ActionName("Logout")]
        public async Task<IActionResult> Logout(VendedorModel vendedor)
        {
            Autenticar();
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
