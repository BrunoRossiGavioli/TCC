using AutoMapper;
using System;
using System.Linq;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;
using TCCESTOQUE.ViewModel.EditViewModels;

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
            return _context.ClienteModel.FirstOrDefault(m => m.Id == id);
        }

        public object PostCriacao(ClienteViewModel cliViewModel)
        {
            try
            {
                var cliente = _mapper.Map<ClienteModel>(cliViewModel);
                _context.Add(cliente);
                _context.SaveChanges();

                var endereco = _mapper.Map<ClienteEnderecoModel>(cliViewModel);
                endereco.ClienteId = cliente.Id;
                _context.Add(endereco);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                // gravar log
                return false;
            }
            
        }

        public ClienteEditViewModel GetEdicao(int? id)
        {
            var cliente = _mapper.Map<ClienteEditViewModel>(_context.ClienteModel.Find(id));
            return cliente;
        }

        public object PutEdicao(int id, ClienteEditViewModel cliente)
        {
            var cli = _mapper.Map<ClienteModel>(cliente);
            var endereco = _mapper.Map<ClienteEnderecoModel>(cliente);

            cli.Id = id;
            endereco.ClienteId = cli.Id;

            try
            {

                _context.Update(cli);
                _context.Update(endereco);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ClienteModel GetExclusao(int? id)
        {
            return _context.ClienteModel.FirstOrDefault(m => m.Id == id);
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
            var cliente = _context.ClienteModel.Where(e => e.Endereco.Id == cliEndereco.Id).FirstOrDefault();
            var info = _mapper.Map<ClienteViewModel>(cliEndereco);
            info.Nome = cliente.Nome;
            info.Cpf = cliente.Cpf;
            info.Telefone = cliente.Telefone;
            info.Email = cliente.Email;
            return info;
        }

        public ClienteModel GetbyEmail(string email)
        {
            return _context.ClienteModel.Where(a => a.Email == email).FirstOrDefault();
        }

        public ClienteModel GetByPhone(string telefone)
        {
            return _context.ClienteModel.Where(a => a.Telefone == telefone).FirstOrDefault();
        }

        public ClienteModel GetByCpf(string cpf)
        {
            return _context.ClienteModel.Where(a => a.Cpf == cpf).FirstOrDefault();
        }
    }
}
