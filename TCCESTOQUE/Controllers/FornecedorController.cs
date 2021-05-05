using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Controllers
{
    public class FornecedorController : ControllerPai
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService context)
        {
            _fornecedorService = context;
        }

        [Authorize]
        public IActionResult CadastroFull()
        {
            Autenticar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult CadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {
            Autenticar();
            var res = _fornecedorService.PostCadastroFull(feviewmodel);
            if (!res.IsValid)
                return View(MostrarErros(res, feviewmodel));
                
            return RedirectToAction("Index", "Fornecedor");
        }
        // GET: Fornecedor
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_fornecedorService.GetAll());
        }

        // GET: Fornecedor/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            Autenticar();
            return View(_fornecedorService.GetOne(id));
        }

        // GET: Fornecedor/EditFull/5
        [Authorize]
        public IActionResult EditFull(int? id)
        {
            Autenticar();
            var edit = _fornecedorService.GetEditFull(id);
            return View(edit);
            
            //if (edit == null) { 
            //    Criar uma pagina para informar que Fornecedo não existe!
            //return RedirectToAction();
            //}

        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EditFull(int id, FornecedorEnderecoViewModel feviewmodel)
        {
            Autenticar();
            var res = _fornecedorService.PutEditFull(id, feviewmodel);

            if (!res.IsValid)
                return View(MostrarErros(res, feviewmodel));
                
            return RedirectToAction("Index", "Fornecedor");
        }

        // GET: Fornecedor/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Autenticar();
            return View(_fornecedorService.GetOne(id));
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            var res = _fornecedorService.PostExclusao(id);
            if(res.GetType() == typeof(bool)) {
                ViewBag.ErroExcluir = "";
                return RedirectToAction("Index", "Fornecedor");
            }

            ViewBag.FornecedorErroExcluir = (string)res;
            return View(_fornecedorService.GetOne(id));
        }
    }
}
