﻿using System;
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
    public class EntradaController : ControllerPai
    {
        private readonly IEntradaService _entradaService;
        private readonly ISelectListService _selectListService;
        public EntradaController(IEntradaService context, ISelectListService selectListService)
        {
            _entradaService = context;
            _selectListService = selectListService;
        }

        // GET: Entrada
        public IActionResult Index()
        {
            Autenticar();
            return View(_entradaService.GetAll(ViewBag.usuarioId));
        }

        // GET: Entrada/Details/5
        public IActionResult Details(Guid? id)
        {
            Autenticar();
            var entrada = _entradaService.GetOne(id);
            if (entrada == null)
                return NotFound();

            return View(entrada);
        }

        // GET: Entrada/Create
        public IActionResult Create()
        {
            Autenticar();
            ViewData["FornecedorId"] = _selectListService.SelectListFornecedor("FornecedorId","NomeFantasia", ViewBag.usuarioId);
            ViewData["ProdutoId"] = _selectListService.SelectListProduto("ProdutoId", "Nome",ViewBag.usuarioId);
            return View();
        }

        // POST: Entrada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EntradaModel entradaModel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                _entradaService.PostEntrada(entradaModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = _selectListService.SelectListFornecedor("FornecedorId", "NomeFantasia", entradaModel.FornecedorId, ViewBag.usuarioId);
            ViewData["ProdutoId"] = _selectListService.SelectListProduto("ProdutoId", "Nome", entradaModel.ProdutoId, ViewBag.usuarioId);
            return View(entradaModel);
        }

        // GET: Entrada/Delete/5
        public IActionResult Delete(Guid? id)
        {
            Autenticar();
            var entrada = _entradaService.GetOne(id);
            if (entrada == null)
                return NotFound();

            return View(entrada);
        }

        // POST: Entrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(EntradaModel entradaModel)
        {
            Autenticar();
            var saida = _entradaService.CancelarEntrada(entradaModel);
            if(saida != "") { 
                ModelState.AddModelError("", saida);
                return View(entradaModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}