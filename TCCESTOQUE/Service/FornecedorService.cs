using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;

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

        public object GetCriacao()
        {
            return _fornecedorRepository.GetCriacao();
        }

        public FornecedorModel GetDetalhes(int? id)
        {
            return _fornecedorRepository.GetDetalhes(id);
        }

        public FornecedorModel GetEdicao(int? id)
        {
            return _fornecedorRepository.GetEdicao(id);
        }

        public FornecedorModel GetExclusao(int? id)
        {
            return _fornecedorRepository.GetExclusao(id);
        }

        public bool PostCriacao(FornecedorModel fornecedorModel)
        {
            return _fornecedorRepository.PostCriacao(fornecedorModel);
        }

        public object PostExclusao(int id)
        {
           return _fornecedorRepository.PostExclusao(id);
        }

        public bool PutEdicao(int id, FornecedorModel fornecedorModel)
        {
            return _fornecedorRepository.PutEdicao(id, fornecedorModel);
        }
    }
}
