using Microsoft.AspNetCore.Mvc;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Controllers
{
    public class ClienteController : ControllerPai
    {
        private readonly IClienteService _context;

        public ClienteController(IClienteService context)
        {
            _context = context;
        }

        // GET: Cliente
        public IActionResult Index()
        {
            Autenticar();
            return View(_context.GetIndex());
        }

        // GET: Cliente/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _context.GetDetalhes(id);

            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // GET: Cliente/Create
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
        public IActionResult Create(ClienteViewModel clienteModel, int Vendedorid)
        {
            Autenticar();
            var res = _context.PostCriacao(clienteModel, Vendedorid);
            if (res != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5/VendedorId
        public IActionResult Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _context.GetEdicao(id);
            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteEditViewModel clienteModel, int VendedorId)
        {
            Autenticar();
            if (id != clienteModel.ClienteId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var res = _context.PutEdicao(id, clienteModel, VendedorId);
                if (res != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _context.GetExclusao(id);

            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _context.PostExclusao(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
