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
    public class ClienteController : ControllerPai
    {
        private readonly TCCESTOQUEContext _context;

        public ClienteController(TCCESTOQUEContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            Autenticar();
            return View(await _context.ClienteModel.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = await _context.ClienteModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            
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

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nome,Cpf,Email,Telefone")] ClienteModel clienteModel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                _context.Add(clienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = await _context.ClienteModel.FindAsync(id);
            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,Cpf,Email,Telefone")] ClienteModel clienteModel)
        {
            Autenticar();
            if (id != clienteModel.ClienteId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.ClienteId))
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
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = await _context.ClienteModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            
            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Autenticar();
            var clienteModel = await _context.ClienteModel.FindAsync(id);
            _context.ClienteModel.Remove(clienteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(int id)
        {
            return _context.ClienteModel.Any(e => e.ClienteId == id);
        }
    }
}
