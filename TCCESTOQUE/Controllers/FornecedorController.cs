using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ValidadorVendedor;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Controllers
{
    public class FornecedorController : ControllerPai
    {
        private readonly IFornecedorService _context;
        private readonly IMapper _mapper;
        private readonly TCCESTOQUEContext _context2;

        public FornecedorController(IFornecedorService context, IMapper mapper, TCCESTOQUEContext context2)
        {
            _context = context;
            _mapper = mapper;
            _context2 = context2;
        }

        [Authorize]
        public IActionResult CadastroFull()
        {
            Autenticar();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult CadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {
            Autenticar();
            var validator = _context.PostCadastroFull(feviewmodel);
            if (validator)
                return RedirectToAction("Index", "Fornecedor");

            return View();
        }
        // GET: Fornecedor
        [Authorize]
        public IActionResult Index()
        {
            Autenticar();
            return View(_context.GetIndex());
        }

        // GET: Fornecedor/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            Autenticar();
            return View(_context.GetDetalhes(id));
        }

        // GET: Fornecedor/EditFull/5
        [Authorize]
        public IActionResult EditFull(int? id)
        {
            Autenticar();
            var info = _context.GetEditFull(id);

            return View(info);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EditFull(int id, FornecedorEnderecoViewModel feviewmodel)
        {
            Autenticar();
            var info = _context.PutEditFull(id, feviewmodel);

            if (info)
            {
                return RedirectToAction("Index", "Fornecedor");
            }

            return View();
        }

        // GET: Fornecedor/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Autenticar();
            return View(_context.GetExclusao(id));
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            Autenticar();
            _context.PostExclusao(id);
            return RedirectToAction("Index", "Fornecedor");
        }
    }
}
