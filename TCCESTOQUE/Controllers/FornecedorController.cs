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
        public async Task<IActionResult> CadastroFull(ForncedorEnderecoViewModel feviewmodel)
        {
            Autenticar();
            if (ModelState.IsValid)
            {
                var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
                _context2.Add(fornecedor);
                await _context2.SaveChangesAsync();

                var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);
                endereco.FornecedorId = fornecedor.ForncedorId;
                _context2.Add(endereco);
                await _context2.SaveChangesAsync();

                return RedirectToAction("Index", "Fornecedor");
            }

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

        // GET: Fornecedor/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            Autenticar();
            return View(_context.GetEdicao(id));
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
            _context.PutEdicao(id, fornecedorModel);
            return RedirectToAction("Index", "Fornecedor");
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
