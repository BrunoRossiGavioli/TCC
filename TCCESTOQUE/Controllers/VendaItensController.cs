using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Data;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class VendaItensController : ControllerPai
    {
        private readonly TCCESTOQUEContext _context;

        public VendaItensController(TCCESTOQUEContext context)
        {
            _context = context;
        }

        // GET: VendaItens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var vendaItensModel = await _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendaItensId == id);
            if (vendaItensModel == null)
            {
                return NotFound();
            }

            return View(vendaItensModel);
        }

        // GET: VendaItens/Create
        public IActionResult Create()
        {
            Autenticar();
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "ProdutoId", "Nome");
            ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", ViewBag.SelectVendaId);
            return View();
        }

        // POST: VendaItens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaItensId,VendaId,ProdutoId,Quantidade")] VendaItensModel vendaItensModel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                _context.Add(vendaItensModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Venda");
            }
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // GET: VendaItens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var vendaItensModel = await _context.VendaItensModel.FindAsync(id);
            if (vendaItensModel == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // POST: VendaItens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaItensId,VendaId,ProdutoId,Quantidade")] VendaItensModel vendaItensModel)
        {
            Autenticar();
            if (id != vendaItensModel.VendaItensId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaItensModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaItensModelExists(vendaItensModel.VendaItensId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // GET: VendaItens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var vendaItensModel = await _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendaItensId == id);
            if (vendaItensModel == null)
            {
                return NotFound();
            }

            return View(vendaItensModel);
        }

        // POST: VendaItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Autenticar();
            var vendaItensModel = await _context.VendaItensModel.FindAsync(id);
            _context.VendaItensModel.Remove(vendaItensModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaItensModelExists(int id)
        {
            return _context.VendaItensModel.Any(e => e.VendaItensId == id);
        }
    }
}
