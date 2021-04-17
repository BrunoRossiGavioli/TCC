using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class ClienteController : ControllerPai
    {
        private readonly IClienteService _context;

        public ClienteController(IClienteService context)
        {
            _context = context;
        }

        // GET: Cliente
        public IActionResult Index()
        {
            Autenticar();
            return View(_context.GetIndex());
        }

        // GET: Cliente/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _context.GetDetalhes(id);

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
        public IActionResult Create([Bind("ClienteId,Nome,Cpf,Email,Telefone")] ClienteModel clienteModel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                _context.PostCriacao(clienteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public IActionResult Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _context.GetEdicao(id);
            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ClienteId,Nome,Cpf,Email,Telefone")] ClienteModel clienteModel)
        {
            Autenticar();
            if (id != clienteModel.ClienteId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.PutEdicao(id, clienteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var clienteModel = _context.GetExclusao(id);

            if (clienteModel == null)
                return NotFound();

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _context.PostExclusao(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
