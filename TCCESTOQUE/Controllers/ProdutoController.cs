using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class ProdutoController : ControllerPai
    {
        private readonly IProdutoService _context;
        private readonly TCCESTOQUEContext _context2;

        public ProdutoController(IProdutoService context, TCCESTOQUEContext context2)
        {
            _context = context;
            _context2 = context2;
        }

        // GET: Produto
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_context.GetIndex());
        }

        // GET: Produto/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            Autenticar();
            return View(_context.GetDetalhes(id));
        }

        // GET: Produto/Create
        [Authorize]
        public IActionResult Create()
        {
            Autenticar();
            ViewData["FornecedorId"] = new SelectList(_context2.FornecedorModel, "ForncedorId", "NomeFantasia");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Id,Nome,Descricao,Custo,ValorUnitario,Quantidade,FornecedorId")] ProdutoModel produtoModel)
        {
            Autenticar();
            _context.PostCriacao(produtoModel);
            ViewData["FornecedorId"] = new SelectList(_context2.FornecedorModel, "ForncedorId", "NomeFantasia", produtoModel.FornecedorId);
            return RedirectToAction("Index", "Produto");
        }

        // GET: Produto/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            var produtoModel = _context.GetEdicao(id);
            ViewData["FornecedorId"] = new SelectList(_context2.FornecedorModel, "ForncedorId", "NomeFantasia", produtoModel.FornecedorId);
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, [Bind("Id,Nome,Descricao,Custo,ValorUnitario,Quantidade,FornecedorId")] ProdutoModel produtoModel)
        {
            Autenticar();
            _context.PutEdicao(id, produtoModel);
            ViewData["FornecedorId"] = new SelectList(_context2.FornecedorModel, "ForncedorId", "NomeFantasia", produtoModel.FornecedorId);
            return RedirectToAction("Index", "Produto");
        }

        // GET: Produto/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Autenticar();

            return View(_context.GetExclusao(id));
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _context.PostExclusao(id);
            return RedirectToAction("Index", "Produto");
        }
    }
}
