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
    public class VendedorController : Controller
    {
        private readonly TCCESTOQUEContext _context;

        public VendedorController(TCCESTOQUEContext context)
        {
            _context = context;
        }


        // GET: Vendedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var vendedorModel = await _context.VendedorModel
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (vendedorModel == null)
                {
                    return NotFound();
                }

                return View(vendedorModel);
        }

        // GET: Vendedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Senha,Cpf,Nome,Email,DataNascimento,Endereco,Telefone")] VendedorModel vendedorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(vendedorModel);
        }

        // GET: Vendedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedorModel = await _context.VendedorModel.FindAsync(id);
            if (vendedorModel == null)
            {
                return NotFound();
            }
            return View(vendedorModel);
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Senha,Cpf,Nome,Email,DataNascimento,Endereco,Telefone")] VendedorModel vendedorModel)
        {
            if (id != vendedorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorModelExists(vendedorModel.Id))
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
            return View(vendedorModel);
        }

        // GET: Vendedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedorModel = await _context.VendedorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedorModel == null)
            {
                return NotFound();
            }

            return View(vendedorModel);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedorModel = await _context.VendedorModel.FindAsync(id);
            _context.VendedorModel.Remove(vendedorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorModelExists(int id)
        {
            return _context.VendedorModel.Any(e => e.Id == id);
        }
    }
}
