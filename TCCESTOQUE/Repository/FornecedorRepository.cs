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
                .FirstOrDefault(m => m.ForncedorId == id);

            if (fornecedorModel == null)
                return null;

            return fornecedorModel;
        }

        public FornecedorModel GetExclusao(int? id)
        {
            var fornecedorModel = _context.FornecedorModel
                .FirstOrDefault(m => m.ForncedorId == id);

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

        public FornecedorEnderecoViewModel GetEditFull(int? id)
        {
            return FeviewConvert(_context.FornecedorModel.Find(id));
        }

        public bool PutEditFull(int id, FornecedorEnderecoViewModel feviewmodel)
        {
            var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
            var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);

            fornecedor.ForncedorId = id;
            endereco.FornecedorId = fornecedor.ForncedorId;

            try
            {
                _context.Update(fornecedor);
                _context.Update(endereco);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PostCadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {
            var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
            _context.Add(fornecedor);
            _context.SaveChanges();

            var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);
            endereco.FornecedorId = fornecedor.ForncedorId;
            _context.Add(endereco);
            _context.SaveChanges();

            return true;
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
    }
}
