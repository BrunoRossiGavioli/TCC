using AutoMapper;
using System;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
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

        public FornecedorModel GetDetalhes(int? id)
        {
            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.FornecedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetExclusao(int? id)
        {
            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.FornecedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public object PostExclusao(int id)
        {
            var fornecedorModel = _context.FornecedorModel.Find(id);
            _context.FornecedorModel.Remove(fornecedorModel);
            _context.SaveChanges();
            return nameof(Index);
        }

        public FornecedorModel GetEditFull(int? id)
        {
            return _context.FornecedorModel.Find(id);
        }

        public void PutEdit(FornecedorModel fornecedorModel)
        {
            _context.Update(fornecedorModel);
            _context.SaveChanges();
        }

        public void PostCadastro(FornecedorModel fornecedor)
        {
            _context.Add(fornecedor);
            _context.SaveChanges();
        }

        public FornecedorModel GetByCnpj(string cnpj)
        {
            return _context.FornecedorModel.Where(f => f.Cnpj == cnpj).FirstOrDefault();
        }

        public FornecedorModel GetByRazaoSocial(string razao)
        {
            return _context.FornecedorModel.Where(f => f.RazaoSocial == razao).FirstOrDefault();
        }

        public FornecedorModel GetByNomeFantsia(string nome)
        {
            return _context.FornecedorModel.Where(f => f.NomeFantasia == nome).FirstOrDefault();
        }

        public FornecedorModel GetByEmail(string email)
        {
            return _context.FornecedorModel.Where(f => f.Email == email).FirstOrDefault();
        }
    }
}
