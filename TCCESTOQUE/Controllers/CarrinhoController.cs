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
    public class CarrinhoController : ControllerPai
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly ISelectListService _selectListService;

        public CarrinhoController(ICarrinhoService context, ISelectListService selectListService)
        {
            _carrinhoService = context;
            _selectListService = selectListService;
        }

        // GET: Carrinho/Details/5
        public IActionResult Details(int? id)
        {
            Autenticar();
            if (id == null || id != ViewBag.usuarioId)
                return NotFound();

            var carrinhoModel = _carrinhoService.GetOne(id);

            ViewData["ClienteId"] = _selectListService.SelectListCliente("ClienteId", "Nome");
            ViewData["CarrinhoId"] = carrinhoModel.CarrinhoId;

            if (carrinhoModel == null)
                return NotFound();

            return View(carrinhoModel);
        }

        [HttpPost]
        public IActionResult AdicionarVenda(CarrinhoModel carrinho)
        {
            var car = _carrinhoService.Finalizar(carrinho);
            if(car)
                return RedirectToAction("Index","Venda");

            return BadRequest();
        }
    }
}
