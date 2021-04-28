﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class ProdutoController : ControllerPai
    {
        private readonly IProdutoService _context;
        private readonly ISelectListRepository _selectListRepository;

        public ProdutoController(IProdutoService context, ISelectListRepository selectListRepository)
        {
            _context = context;
            _selectListRepository = selectListRepository;
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
            ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("ForncedorId", "NomeFantasia");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("ProdutoId,Nome,Descricao,Custo,ValorUnitario,Quantidade,FornecedorId, VendedorId")] ProdutoModel produtoModel)
        {
            Autenticar();
            var res = _context.PostCriacao(produtoModel);
            ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("ForncedorId", "NomeFantasia", produtoModel.FornecedorId);
            if (res)
                return RedirectToAction("Index", "Produto");

            return View(produtoModel);
        }

        // GET: Produto/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            var produtoModel = _context.GetEdicao(id);
            ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("ForncedorId", "NomeFantasia", produtoModel.FornecedorId);
            //  ViewData["VendedorId"] = _selectListRepository.SelectListVendedor("VendedorId", "Nome", produtoModel.VendedorId);
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, [Bind("VendedorId,Nome,Custo,Descricao,Quantidade,ValorUnitario,FornecedorId")] ProdutoModel produtoModel)
        {
            Autenticar();
            var res = _context.PutEdicao(id, produtoModel);
            ViewData["FornecedorId"] = _selectListRepository.SelectListFornecedor("ForncedorId", "NomeFantasia", produtoModel.FornecedorId);
            if (res)
                return RedirectToAction("Index", "Produto");

            return View(produtoModel);
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
