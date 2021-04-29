using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Repository
{
    public class FornecedorRepository : BaseRepository<FornecedorModel>, IFornecedorRepository
    {
        
        private readonly IMapper _mapper;

        public FornecedorRepository(TCCESTOQUEContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public object GetIndex()
        {
            return _context.FornecedorModel.ToList();
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

            fornecedor.Id = id;
            endereco.FornecedorId = fornecedor.Id;

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
            endereco.FornecedorId = fornecedor.Id;
            _context.Add(endereco);
            _context.SaveChanges();

            return true;
        }

        public FornecedorEnderecoViewModel FeviewConvert(FornecedorModel fornecedor)
        {
            var endereco = _context.FornecedorEnderecoModel.Where(e => e.FornecedorId == fornecedor.Id).FirstOrDefault();
            var info = _mapper.Map<FornecedorEnderecoViewModel>(fornecedor);
            info.Bairro = endereco.Bairro;
            info.Cep = endereco.Cep;
            info.Complemento = endereco.Complemento;
            info.Localidade = endereco.Localidade;
            info.Logradouro = endereco.Logradouro;
            info.Numero = endereco.Numero;
            info.Uf = endereco.Uf;
            info.EnderecoId = endereco.Id;

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

        public FornecedorModel GetByNomeFantasia(string nome)
        {
            return _context.FornecedorModel.Where(f => f.NomeFantasia == nome).FirstOrDefault();
        }

        public FornecedorModel GetByEmail(string email)
        {
            return _context.FornecedorModel.Where(f => f.Email == email).FirstOrDefault();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FornecedorModel> GetOne(int id)
        {
            return _context.FornecedorModel.Where(f => f.Id == id).FirstOrDefault();
        }
    }
}
