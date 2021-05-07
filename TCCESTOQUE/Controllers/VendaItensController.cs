using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class VendaItensController : ControllerPai
    {
        private readonly IVendaItensService _VendaItensService;
        private readonly ISelectListService _selectListRepository;

        public VendaItensController(IVendaItensService context, ISelectListService selectListRepository)
        {
            _VendaItensService = context;
            _selectListRepository = selectListRepository;
        }

        // GET: VendaItens/Details/5
        [Authorize]
        public IActionResult Details(Guid? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _VendaItensService.GetOne(id);

            if (vendaItensModel == null)
                return NotFound();

            return View(vendaItensModel);
        }

        #region ItemCarrinho
        //GET
        [Authorize]
        public IActionResult ItemCarrinho(Guid id)
        {
            Autenticar();
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome");
            ViewData["CarrinhoId"] = id;
            return View();
        }


        // POST: VendaItens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AdicionarItemCarrinho(VendaItensModel vendaItensModel, Guid carrinhoId)
        {
            Autenticar();
            if (vendaItensModel.CarrinhoId != carrinhoId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var res = _VendaItensService.PostItem(vendaItensModel);
                if (res)
                    return RedirectToAction("Details", "Carrinho", new { id = vendaItensModel.VendedorId });
            }

            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["CarrinhoId"] = carrinhoId;
            return View(vendaItensModel);
        }

        // GET: VendaItens/Edit/5
        [Authorize]
        public IActionResult EditItemCarrinho(Guid? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _VendaItensService.GetOne(id);
            if (vendaItensModel == null)
                return NotFound();

            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["CarrinhoId"] = vendaItensModel.CarrinhoId;
            return View(vendaItensModel);
        }

        // POST: VendaItens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EditItemCarrinho(VendaItensModel vendaItensModel, Guid vendaItensId)
        {
            Autenticar();
            if (vendaItensId != vendaItensModel.VendaItensId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _VendaItensService.PutEdicao(vendaItensModel);
                return RedirectToAction("Details", "Carrinho", new { id = vendaItensModel.VendedorId });
            }
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["CarrinhoId"] = vendaItensModel.CarrinhoId;
            return View(vendaItensModel);
        }

        #endregion

        #region ItemVenda

        // GET: VendaItens/Create
        [Authorize]
        public IActionResult ItemVenda(Guid id)
        {
            Autenticar();
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome");
            ViewData["VendaId"] = id;
            return View();
        }

        // POST: VendaItens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AdicionarItemVenda(VendaItensModel vendaItensModel, Guid vendaId)
        {
            Autenticar();
            if (vendaItensModel.VendaId != vendaId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var res = _VendaItensService.PostItem(vendaItensModel);
                if (res)
                    return RedirectToAction("Index", "Venda", new { id = vendaItensModel.VendaId });
            }

            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = vendaId;
            return View(vendaItensModel);
        }

        // GET: VendaItens/Edit/5
        [Authorize]
        public IActionResult EditItemVenda(Guid? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _VendaItensService.GetOne(id);
            if (vendaItensModel == null)
                return NotFound();

            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = vendaItensModel.VendaId;
            return View(vendaItensModel);
        }

        // POST: VendaItens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EditItemVenda(VendaItensModel vendaItensModel, Guid id)
        {
            Autenticar();
            if (id != vendaItensModel.VendaItensId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _VendaItensService.PutEdicao(vendaItensModel);
                return RedirectToAction("Index", "Venda", new { id = vendaItensModel.VendaId });
            }
            ViewData["ProdutoId"] = _selectListRepository.SelectListProduto("ProdutoId", "Nome", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = vendaItensModel.VendaId;
            return View(vendaItensModel);
        }

        #endregion

        // GET: VendaItens/Delete/5
        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            Autenticar();
            if (id == null)
                return NotFound();

            var vendaItensModel = _VendaItensService.GetOne(id);

            if (vendaItensModel == null)
                return NotFound();

            return View(vendaItensModel);
        }

        // POST: VendaItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(Guid id)
        {
            Autenticar();
            var res = _VendaItensService.PostExclusao(id);
            if(res)
                return RedirectToAction("Index","Venda");

            ModelState.AddModelError("", "Não foi possivel excluir o item, tente novamente mais tarde!");
            return View(_VendaItensService.GetOne(id));
        }
    }
}
