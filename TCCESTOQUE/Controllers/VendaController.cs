using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Data;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Controllers
{
    public class VendaController : ControllerPai
    {
        private readonly TCCESTOQUEContext _context;
        private readonly IMapper _mapper;

        public VendaController(TCCESTOQUEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            Autenticar();
            var tCCESTOQUEContext = _context.VendaModel.Include(v => v.Cliente).Include(v => v.Vendedor);
            return View(await tCCESTOQUEContext.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();
            var itens = _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Produto.Fornecedor)
                .ToList();
            
            var vendaModel = await _context.VendaModel
                .Include(v => v.Itens)
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            vendaModel.Itens = itens;

            if (vendaModel == null)
                return NotFound();

            return View(vendaModel);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            Autenticar();
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "ProdutoId", "Nome");
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Nome");
            ViewData["VendedorId"] = new SelectList(_context.VendedorModel, "VendedorId", "Nome");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendaViewModel vendaViewModel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                var venda = _mapper.Map<VendaModel>(vendaViewModel);
                var itens = _mapper.Map<VendaItensModel>(vendaViewModel);

                _context.Add(venda);
                await _context.SaveChangesAsync();
                itens.VendaId = venda.VendaId;
                _context.Add(itens);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Venda");
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Nome", vendaViewModel.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.VendedorModel, "VendedorId", "Nome", vendaViewModel.VendedorId);
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "ProdutoId", "Nome", vendaViewModel.ProdutoId);
            return View(vendaViewModel);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaModel = await _context.VendaModel.FindAsync(id);
            if (vendaModel == null)
                return NotFound();

            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Nome", vendaModel.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.VendedorModel, "VendedorId", "Nome", vendaModel.VendedorId);
            return View(vendaModel);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,Valor,DataVenda,VendedorId,ClienteId")] VendaModel vendaModel)
        {
            Autenticar();
            if (id != vendaModel.VendaId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaModelExists(vendaModel.VendaId))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "Nome", vendaModel.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.VendedorModel, "VendedorId", "Nome", vendaModel.VendedorId);
            return View(vendaModel);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaModel = await _context.VendaModel
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (vendaModel == null)
                return NotFound();

            return View(vendaModel);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Autenticar();
            var vendaModel = await _context.VendaModel.FindAsync(id);
            _context.VendaModel.Remove(vendaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaModelExists(int id)
        {
            return _context.VendaModel.Any(e => e.VendaId == id);
        }
    }
}
