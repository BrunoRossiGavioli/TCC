using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models; 

namespace TCCESTOQUE.Controllers
{
    public class ProdutoController : ControllerPai
    {
        private readonly IProdutoService _context;

        public ProdutoController(IProdutoService context)
        {
            _context = context;
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
            ViewData["FornecedorId"] = _context.GetCriacao(); 
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
            var result = _context.PostCriacao(produtoModel);
            if(result)
            return RedirectToAction("Index", "Produto");
            

        return View(produtoModel);
        }

        // GET: Produto/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            var produtoModel = _context.GetEdicao(id);
            
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
            var result = _context.PutEdicao(id, produtoModel);
            if(result)                                       
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
