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
    public class FornecedorController : ControllerPai
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: Fornecedor
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_fornecedorService.GetIndex());
        }

        // GET: Fornecedor/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            Autenticar();
            return View(_fornecedorService.GetDetalhes(id));
        }

        // GET: Fornecedor/Create
        [Authorize]
        public IActionResult Create()
        {
            Autenticar();
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("NomeFantasia,Cnpj,Nome,Email,DataNascimento,Endereco,Telefone")] FornecedorModel fornecedorModel)
        {
            Autenticar();
             var res = _fornecedorService.PostCriacao(fornecedorModel);
            if (res)            
            return RedirectToAction("Index", "Fornecedor");

            return View(fornecedorModel);
        }

        // GET: Fornecedor/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            return View(_fornecedorService.GetEdicao(id));
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(int id, [Bind("NomeFantasia,Cnpj,Nome,Email,DataNascimento,Endereco,Telefone")] FornecedorModel fornecedorModel)
        {
            Autenticar();
            _fornecedorService.PutEdicao(id, fornecedorModel);
            return RedirectToAction("Index", "Fornecedor");
        }

        // GET: Fornecedor/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Autenticar();
            return View(_fornecedorService.GetExclusao(id));
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _fornecedorService.PostExclusao(id);
            return RedirectToAction("Index", "Fornecedor");
        }
    }
}
