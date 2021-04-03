using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.Validacao.Formatacao; 

namespace TCCESTOQUE.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly TCCESTOQUEContext _context;

        public FornecedorRepository(TCCESTOQUEContext context)
        {
            _context = context;
        }

        public object GetIndex()
        {
            return _context.FornecedorModel.ToList();
        }

        public object GetCriacao()
        {
            return null;
        }

        public FornecedorModel GetDetalhes(int? id)
        {
            if (id == null)
                return null;

            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.Id == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetEdicao(int? id)
        {
            if (id == null)
                return null;

            var fornecedorModel = _context.FornecedorModel.Find(id);
            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetExclusao(int? id)
        {
            if (id == null)
                return null;

            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.Id == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public bool PostCriacao(FornecedorModel fornecedorModel)
        {
            var validacao = new FornecedorValidador().Validate(fornecedorModel);
            if(validacao.IsValid)
            {
            fornecedorModel = FormataValores.FormataValoresFornecedor(fornecedorModel);                
            _context.Add(fornecedorModel);
            _context.SaveChanges();
            return true;
            }

        return false;
        }

        public object PostExclusao(int id)
        {
            var fornecedorModel = _context.FornecedorModel.Find(id);
            _context.FornecedorModel.Remove(fornecedorModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public bool PutEdicao(int id, FornecedorModel fornecedorModel)
        {
            fornecedorModel.Id = id;
            var validacao = new FornecedorValidador().Validate(fornecedorModel);
            if (validacao.IsValid)
            {
                try
                {
                    fornecedorModel = FormataValores.FormataValoresFornecedor(fornecedorModel); 
                    _context.Update(fornecedorModel);
                    _context.SaveChanges();
                    return true;
                }
                catch (DbUpdateConcurrencyException) 
                { 
                    return false;
                }               
            }
            return false;
        }
    }
}
