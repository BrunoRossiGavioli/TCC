﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Controllers
{
    public class VendaController : ControllerPai
    {
        private readonly IVendaService _context;

        public VendaController(IVendaService context)
        {
            _context = context;
        }

        // GET: Venda
        public IActionResult Index()
        {
            Autenticar();
            return View(_context.GetIndex());
        }

        // GET: Venda/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaModel = _context.GetDetalhes(id);

            if (vendaModel == null)
                return NotFound();

            return View(vendaModel);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            Autenticar();
            ViewData["ProdutoId"] = _context.SelectListProduto("ProdutoId", "Nome");
            ViewData["ClienteId"] = _context.SelectListCliente("ClienteId", "Nome");
            ViewData["VendedorId"] = _context.SelectListVendedor("VendedorId", "Nome");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VendaViewModel vendaViewModel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                _context.PostCricao(vendaViewModel);
                return RedirectToAction("Index", "Venda");
            }
            ViewData["ClienteId"] = _context.SelectListCliente("ClienteId", "Nome", vendaViewModel.ClienteId);
            ViewData["VendedorId"] = _context.SelectListVendedor("VendedorId", "Nome", vendaViewModel.VendedorId);
            ViewData["ProdutoId"] = _context.SelectListProduto("ProdutoId", "Nome", vendaViewModel.ProdutoId);
            return View(vendaViewModel);
        }

        // GET: Venda/Edit/5
        public IActionResult Edit(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaModel = _context.GetEdicao(id);
            if (vendaModel == null)
                return NotFound();

            ViewData["ClienteId"] = _context.SelectListCliente("ClienteId", "Nome", vendaModel.ClienteId);
            ViewData["VendedorId"] = _context.SelectListVendedor("VendedorId", "Nome", vendaModel.VendedorId);
            return View(vendaModel);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VendaId,Valor,DataVenda,VendedorId,ClienteId")] VendaModel vendaModel)
        {
            Autenticar();
            if (id != vendaModel.VendaId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.PutEdicao(id, vendaModel);
                }
                catch (Exception)
                {
                    return View(vendaModel);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = _context.SelectListCliente("ClienteId", "Nome", vendaModel.ClienteId);
            ViewData["VendedorId"] = _context.SelectListVendedor("VendedorId", "Nome", vendaModel.VendedorId);
            return View(vendaModel);
        }

        // GET: Venda/Delete/5
        public IActionResult Delete(int? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaModel = _context.GetExclusao(id);
            if (vendaModel == null)
                return NotFound();

            return View(vendaModel);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            var vendaModel = _context.PostExclusao(id);
            return RedirectToAction(nameof(Index));
        }
    }
}