using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Controllers
{
    public class ClienteController : ControllerPai
    {
        private readonly IClienteService _cliService;

        public ClienteController(IClienteService context)
        {
            _cliService = context;
        }

        // GET: Cliente
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_cliService.GetAll());
        }

        // GET: Cliente/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _cliService.GetOne(id);

            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // GET: Cliente/Create
        [Authorize]
        public IActionResult Create()
        {
            Autenticar();
            return View();
        }

        // POST: Cliente/Create/VendedorId
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(ClienteViewModel cliVM)
        {
            Autenticar();
            var res = _cliService.PostCriacao(cliVM);
            if (!res.IsValid)
                return View(MostrarErros(res, cliVM));

            return RedirectToAction(nameof(Index));
        }

        // GET: Cliente/Edit/5/VendedorId
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _cliService.GetEdicao(id);
            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, ClienteViewModel cliVM)
        {
            Autenticar();
            if (id != cliVM.ClienteId)
                return NotFound();

            var res = _cliService.PutEdicao(cliVM);
            if (!res.IsValid)
                return View(MostrarErros(res, cliVM));

            return RedirectToAction(nameof(Index));
        }

        // GET: Cliente/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _cliService.GetOne(id);

            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            var res = _cliService.PostExclusao(id);
            if (res)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Não foi possivel deletar o cliente, tente novamente mais tarde!");
            return View(_cliService.GetOne(id));
        }
    }
}
