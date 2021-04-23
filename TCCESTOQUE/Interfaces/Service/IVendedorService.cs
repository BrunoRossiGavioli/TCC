﻿using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService
    {
        public VendedorModel GetDetalhes(int? id);
        public object GetCriacao();
        public bool PostCriacao(VendedorModel vendedorModel);
        public VendedorModel GetEdicao(int? id);
        public VendedorModel PutEdicao(VendedorModel vendedorModel);
        public VendedorModel GetExclusao(int? id);
        public object PostExclusao(int id);
        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel);
        public VendedorModel GetEmail(string email);
        public object GetSenha(string senha);
    }
}
