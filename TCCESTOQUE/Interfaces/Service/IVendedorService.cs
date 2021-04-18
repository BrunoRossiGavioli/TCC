﻿using System.Security.Claims;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IVendedorService
    {
        public VendedorModel GetDetalhes(int? id);

        public object GetCriacao();

        public bool PostCriacao(VendedorModel vendedorModel);

        public VendedorModel GetEdicao(int? id);

        public bool PutEdicao(int id, VendedorModel vendedorModel);

        public VendedorModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public object GetEmail(string email);

        public object GetSenha(string senha);

        public ClaimsPrincipal PostLogin(LoginVendedorViewModel vendedorModel);
    }
}
