using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly TCCESTOQUEContext _context;
        private readonly IMapper _mapper;

        public FornecedorRepository(TCCESTOQUEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                .FirstOrDefault(m => m.ForncedorId == id);

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
                .FirstOrDefault(m => m.ForncedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public object PostCriacao(FornecedorModel fornecedorModel)
        {
            _context.Add(fornecedorModel);
            _context.SaveChanges();
            return fornecedorModel;
        }

        public object PostExclusao(int id)
        {
            var fornecedorModel = _context.FornecedorModel.Find(id);
            _context.FornecedorModel.Remove(fornecedorModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public object PutEdicao(int id, FornecedorModel fornecedorModel)
        {
            if (fornecedorModel.ForncedorId == 0)
                fornecedorModel.ForncedorId = id;
            try
            {
                _context.Update(fornecedorModel);
                _context.SaveChanges();
                return nameof(Index);
            }
            catch (Exception) 
            { 
                throw;
            }
        }

        public FornecedorEnderecoViewModel GetEditFull(int? id)
        {
            var fornecedor = _context.FornecedorModel.Find(id);
            var info = FeviewConvert(fornecedor);
            return info;
        }

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel)
        {
            var validator = new FornecedorEnderecoValidador().Validate(feviewmodel);
            var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
            var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);

            if (fornecedor.ForncedorId == 0) 
                fornecedor.ForncedorId = id;

            endereco.FornecedorId = fornecedor.ForncedorId;

            //endereco.EnderecoId = _context.FornecedorEnderecoModel.Where(e => e.FornecedorId == fornecedor.ForncedorId).FirstOrDefault().EnderecoId;

            if (validator.IsValid)
            {
                _context.Update(fornecedor);
                //_context.SaveChangesAsync();

                _context.FornecedorEnderecoModel.Update(endereco);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public FornecedorEnderecoViewModel FeviewConvert(FornecedorModel fornecedor)
        {
            var endereco = _context.FornecedorEnderecoModel.Where(e => e.FornecedorId == fornecedor.ForncedorId).FirstOrDefault();
            var info = _mapper.Map<FornecedorEnderecoViewModel>(fornecedor);
            info.Bairro = endereco.Bairro;
            info.Cep = endereco.Cep;
            info.Complemento = endereco.Complemento;
            info.Localidade = endereco.Localidade;
            info.Logradouro = endereco.Logradouro;
            info.Numero = endereco.Numero;
            info.Uf = endereco.Uf;
            info.EnderecoId = endereco.EnderecoId;

            return info;
        }
    }
}
