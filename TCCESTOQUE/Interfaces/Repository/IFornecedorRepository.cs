using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Interfaces.Repository
{
    public interface IFornecedorRepository
    {
        public object GetIndex();

        public FornecedorModel GetDetalhes(int? id);

        public object GetCriacao();

        public object PostCriacao(FornecedorModel fornecedorModel);

        public FornecedorModel GetEdicao(int? id);

        public object PutEdicao(int id, FornecedorModel fornecedorModel);

        public FornecedorModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
