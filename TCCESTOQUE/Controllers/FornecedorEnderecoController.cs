using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class FornecedorEnderecoController : ControllerPai
    {
        private readonly TCCESTOQUEContext _context2;

        public FornecedorEnderecoController(TCCESTOQUEContext context2)
        {
            _context2 = context2;
        }

        // GET: FornecedorEndereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var fornecedorEnderecoModel = await _context2.FornecedorEnderecoModel.FindAsync(id);
            if (fornecedorEnderecoModel == null)
                return NotFound();

            ViewData["FornecedorId"] = new SelectList(_context2.FornecedorModel, "ForncedorId", "Nome", fornecedorEnderecoModel.FornecedorId);
            return View(fornecedorEnderecoModel);
        }

        // POST: FornecedorEndereco/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorId,Id,Cep,Logradouro,Complemento,Numero,Bairro,Localidade,Uf")] FornecedorEnderecoModel fornecedorEnderecoModel)
        {
            Autenticar();
            if (id != fornecedorEnderecoModel.EnderecoId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context2.Update(fornecedorEnderecoModel);
                    await _context2.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorEnderecoModelExists(fornecedorEnderecoModel.EnderecoId))
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
            ViewData["FornecedorId"] = new SelectList(_context2.FornecedorModel, "ForncedorId", "Nome", fornecedorEnderecoModel.FornecedorId);
            return View(fornecedorEnderecoModel);
        }

        // GET: FornecedorEndereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Autenticar();
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorEnderecoModel = await _context2.FornecedorEnderecoModel
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(m => m.EnderecoId == id);
            if (fornecedorEnderecoModel == null)
            {
                return NotFound();
            }

            return View(fornecedorEnderecoModel);
        }

        // POST: FornecedorEndereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Autenticar();
            var fornecedorEnderecoModel = await _context2.FornecedorEnderecoModel.FindAsync(id);
            _context2.FornecedorEnderecoModel.Remove(fornecedorEnderecoModel);
            await _context2.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorEnderecoModelExists(int id)
        {
            return _context2.FornecedorEnderecoModel.Any(e => e.EnderecoId == id);
        }
    }
}
