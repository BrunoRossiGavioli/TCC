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
    public class ClienteRepository : IClienteRepository
    {
        private readonly TCCESTOQUEContext _context;
        private readonly IMapper _mapper;

        public ClienteRepository(TCCESTOQUEContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public object GetIndex()
        {
            return _context.ClienteModel.ToList();
        }

        public ClienteModel GetDetalhes(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.ClienteId == id);
        }

        public object PostCriacao(ClienteViewModel cliViewModel)
        {
                var cliente = _mapper.Map<ClienteModel>(cliViewModel);
                _context.Add(cliente);
                _context.SaveChanges();

                var endereco = _mapper.Map<ClienteEnderecoModel>(cliViewModel);
                endereco.ClienteId = cliente.ClienteId;
                _context.Add(endereco);
                _context.SaveChanges();

                return true;
        }

        public ClienteViewModel GetEdicao(int? id)
        {
            return ConvertCliViewModel(_context.ClienteEnderecoModel.Find(id));
        }

        public object PutEdicao(int id, ClienteViewModel cliente)
        {
            var cli = _mapper.Map<ClienteModel>(cliente);
            var endereco = _mapper.Map<ClienteEnderecoModel>(cliente);

            cli.ClienteId = id;
            endereco.ClienteId = cli.ClienteId;

            try
            {

                _context.Update(cli);
                _context.Update(endereco);
                _context.SaveChanges();
                return true;
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        public ClienteModel GetExclusao(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.ClienteId == id);
        }

        public object PostExclusao(int id)
        {
            try
            {
                var clienteModel = _context.ClienteModel.Find(id);
                _context.ClienteModel.Remove(clienteModel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ClienteViewModel ConvertCliViewModel(ClienteEnderecoModel cliEndereco)
        {
            var cliente = _context.ClienteModel.Where(e => e.Endereco.EnderecoId == cliEndereco.EnderecoId).FirstOrDefault();
            var info = _mapper.Map<ClienteViewModel>(cliEndereco);
            info.Nome = cliente.Nome;
            info.Cpf = cliente.Cpf;
            info.Telefone = cliente.Telefone;
            info.Email = cliente.Email;
            return info;
        }
    }
}
