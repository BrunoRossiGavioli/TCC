using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly TCCESTOQUEContext _context;
        private readonly IMapper _mapper;

        public VendedorRepository(TCCESTOQUEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public object GetCriacao()
        {
            return _context.VendedorModel.ToList();
        }

        public bool PostCriacao(VendedorModel vendedorModel)
        {
            _context.Add(vendedorModel);
            _context.SaveChanges();
            return true;
        }

        public VendedorModel GetDetalhes(int? id)
        {
            var vendedorModel = _context.VendedorModel
                .FirstOrDefault(m => m.VendedorId == id);

            if (vendedorModel == null)
                return null;

            return vendedorModel;
        }

        public VendedorEditViewModel GetEdicao(int? id)
        {
            var vendedor = _mapper.Map<VendedorEditViewModel>(_context.VendedorModel.Find(id));
            return vendedor;
        }

        public bool PutEdicao(int id, VendedorEditViewModel vendedorModel)
        {
            vendedorModel.VendedorId = id;
            var mapeamento = _mapper.Map<VendedorModel>(vendedorModel);

            try
            {
                _context.Update(mapeamento);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public VendedorModel GetExclusao(int? id)
        {
            var vendedor = _context.VendedorModel
                .FirstOrDefault(m => m.VendedorId == id);

            if (vendedor == null)
                return null;

            return vendedor;
        }

        public object PostExclusao(int id)
        {
            var vendedorModel = _context.VendedorModel.Find(id);
            if (vendedorModel.VendedorId == id)
            {
                _context.VendedorModel.Remove(vendedorModel);
                _context.SaveChanges();
            }
            return null;

        }

        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel)
        {
            var vendedor = _context.VendedorModel.Where(a => a.Email == vendedorModel.Email).FirstOrDefault();
            if (vendedor == null)
                return null;
            if (vendedor.Senha != SecurityService.Criptografar(vendedorModel.Senha))
                return null;


            var claim1 = new Claim(ClaimTypes.Name, vendedor.Nome);
            var claim2 = new Claim(ClaimTypes.Email, vendedor.Email);
            var claim3 = new Claim(ClaimTypes.SerialNumber, Convert.ToString(vendedor.VendedorId));
            IList<Claim> Claims = new List<Claim>()
            {
                claim1,
                claim2,
                claim3
            };

            var minhaIdentity = new ClaimsIdentity(Claims, "Vendedor");
            var vendPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
            return vendPrincipal;
        }

        public VendedorModel GetByCpf(string cpf)
        {
            return _context.VendedorModel.Where(a => a.Cpf == cpf).FirstOrDefault();
        }

        public VendedorModel GetByPhone(string telefone)
        {
            return _context.VendedorModel.Where(a => a.Telefone == telefone).FirstOrDefault();
        }

        public VendedorModel GetByEmail(string email)
        {
            return _context.VendedorModel.Where(a => a.Email == email).FirstOrDefault();
        }

        public VendedorModel GetSenha(string senha)
        {
            return _context.VendedorModel.Where(a => a.Senha == SecurityService.Criptografar(senha)).FirstOrDefault();
        }

    }
}
