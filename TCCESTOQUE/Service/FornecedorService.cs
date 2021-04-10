using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public object GetIndex()
        {
            return _fornecedorRepository.GetIndex();
        }
        public FornecedorModel GetDetalhes(int? id)
        {
            return _fornecedorRepository.GetDetalhes(id);
        }

        public FornecedorModel GetExclusao(int? id)
        {
            return _fornecedorRepository.GetExclusao(id);
        }

        public object PostExclusao(int id)
        {
           return _fornecedorRepository.PostExclusao(id);
        }

        public FornecedorEnderecoViewModel GetEditFull(int? id)
        {
            return _fornecedorRepository.GetEditFull(id);
        }

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel)
        {
            return _fornecedorRepository.PutEditFull(id, feviewmodel);
        }
    }
}
