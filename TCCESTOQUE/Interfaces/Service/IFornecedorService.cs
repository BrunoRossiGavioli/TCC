using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService
    {
        public object GetIndex();

        public FornecedorModel GetDetalhes(int? id);

        public object GetCriacao();

        public bool PostCriacao(FornecedorModel fornecedorModel);

        public FornecedorModel GetEdicao(int? id);

        public bool PutEdicao(int id, FornecedorModel fornecedorModel);

        public FornecedorModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
