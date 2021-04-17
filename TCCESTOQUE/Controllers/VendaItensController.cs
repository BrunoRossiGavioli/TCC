using Microsoft.AspNetCore.Mvc;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class VendaItensController : ControllerPai
    {
        private readonly IVendaItensService _context;
        private readonly ISelectListRepository _selectListRepository;

        public VendaItensController(IVendaItensService context, ISelectListRepository selectListRepository)
        {
            _context = context;
            _selectListRepository = selectListRepository;
        }

        // GET: VendaItens/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _context.GetDetalhes(id);

            if (vendaItensModel == null)
                return NotFound();

            return View(vendaItensModel);
        }

        // GET: VendaItens/Create
        public IActionResult Create(int id)
        {
            Autenticar();
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome");
            ViewData["VendaId"] = _selectListRepository.SelectListVenda("VendaId", "VendaId", id);
            return View();
        }

        // POST: VendaItens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VendaItensId,VendaId,ProdutoId,Quantidade")] VendaItensModel vendaItensModel, int id)
        {
            Autenticar();

            if (ModelState.IsValid)
            {
                _context.PostCriacao(vendaItensModel, id);
                return RedirectToAction("Index", "Venda");
            }
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = _selectListRepository.SelectListVenda("VendaId", "VendaId", id);
            return View(vendaItensModel);
        }

        // GET: VendaItens/Edit/5
        public IActionResult Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _context.GetEdicao(id);
            if (vendaItensModel == null)
                return NotFound();

            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = _selectListRepository.SelectListVenda("VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // POST: VendaItens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VendaItensId,VendaId,ProdutoId,Quantidade")] VendaItensModel vendaItensModel)
        {
            Autenticar();
            if (id != vendaItensModel.VendaItensId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.PutEdicao(id, vendaItensModel);
                return RedirectToAction("Index","Venda");
            }
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = _selectListRepository.SelectListVenda("VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // GET: VendaItens/Delete/5
        public IActionResult Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _context.GetExclusao(id);

            if (vendaItensModel == null)
                return NotFound();

            return View(vendaItensModel);
        }

        // POST: VendaItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _context.PostExlusao(id);
            return RedirectToAction("Index","Venda");
        }
    }
}
