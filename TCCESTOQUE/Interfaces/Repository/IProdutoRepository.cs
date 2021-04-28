﻿using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        public object GetIndex();

        public ProdutoModel GetDetalhes(int? id);

        public object GetCriacao();

        public bool PostCriacao(ProdutoModel produtoModel);

        public ProdutoModel GetEdicao(int? id);

        public bool PutEdicao(int id, ProdutoModel produtoModel);

        public ProdutoModel GetExclusao(int? id);

        public object PostExclusao(int id);

        public VendedorModel GetByIdVendedor(int id);
    }
}
