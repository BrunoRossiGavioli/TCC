using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class ProdutoController : ControllerPai
    {
        private readonly IProdutoService _produtoService;
        private readonly ISelectListService _selectListRepository;

        public ProdutoController(IProdutoService context, ISelectListService selectListRepository)
        {
            _produtoService = context;
            _selectListRepository = selectListRepository;
        }

        // GET: Produto
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_produtoService.GetAll());
        }

        // GET: Produto/Details/5
        [Authorize]
        public IActionResult Details(Guid? id)
        {
            Autenticar();
            return View(_produtoService.GetOne(id));
        }

        // GET: Produto/Create
        [Authorize]
        public IActionResult Create()
        {
            Autenticar();
            ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("FornecedorId", "NomeFantasia");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(ProdutoModel produtoModel)
        {
            Autenticar();
            var res =_produtoService.PostCriacao(produtoModel);
            if (!res.IsValid)
            {
                ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("FornecedorId", "NomeFantasia", produtoModel.FornecedorId);
                return View(MostrarErros(res, produtoModel));
            }
            
            return RedirectToAction("Index", "Produto");
        }

        // GET: Produto/Edit/5
        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            Autenticar();
            var produtoModel = _produtoService.GetEdicao(id);
            ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("FornecedorId", "NomeFantasia", produtoModel.FornecedorId);
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(Guid id,ProdutoModel produtoModel)
        {
            Autenticar();
            var res =_produtoService.PutEdicao(produtoModel);
            if (!res.IsValid)
            {
                ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("FornecedorId", "NomeFantasia", produtoModel.FornecedorId);
                return View(MostrarErros(res, produtoModel));
            }
            return RedirectToAction("Index", "Produto");
        }

        // GET: Produto/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            Autenticar();

            return View(_produtoService.GetOne(id));
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Autenticar();
            var res = _produtoService.PostExclusao(id);
            if(res)
                return RedirectToAction("Index", "Produto");

            ModelState.AddModelError("", "Não foi possivel excluir esse produto, tente novamente mais tarde!");
            return View(_produtoService.GetOne(id));
        }
    }
}
