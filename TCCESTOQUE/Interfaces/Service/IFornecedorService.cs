using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Interfaces.Service
{
    public interface IFornecedorService
    {
        public object GetIndex();

        public FornecedorModel GetDetalhes(int? id);

        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel);

        public FornecedorEnderecoViewModel GetEditFull(int? id);

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel);

        public FornecedorModel GetExclusao(int? id);

        public object PostExclusao(int id);
    }
}
