using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;
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
            if (id == null)
                return null;

            return _fornecedorRepository.GetDetalhes(id);
        }

        public FornecedorModel GetExclusao(int? id)
        {
            if (id == null)
                return null;

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
            var validator = new FornecedorEnderecoValidador().Validate(feviewmodel);
            if(validator.IsValid)
                return _fornecedorRepository.PutEditFull(id, feviewmodel);

            return false;
        }

        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {
            var validator = new FornecedorEnderecoValidador().Validate(feviewmodel);
            if (validator.IsValid)
                return _fornecedorRepository.PostCadastroFull(feviewmodel);

            return false;
        }
    }
}
