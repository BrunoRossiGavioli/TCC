﻿using AutoMapper;
using FluentValidation.Results;
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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteEnderecoRepository _cliEnderecoRepo;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IClienteEnderecoRepository cliEnderecoRepo, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _cliEnderecoRepo = cliEnderecoRepo;
            _mapper = mapper;
        }
        public ClienteModel GetOne(int? id)
        {
            return _clienteRepository.GetOne(id);
        }

        public ClienteViewModel GetEdicao(int? id)
        {
            return ClienteParaClienteView(_clienteRepository.GetEdicao(id));
        }

        public ICollection<ClienteModel> GetAll()
        {
            return _clienteRepository.GetIndex();
        }

        public ValidationResult PostCriacao(ClienteViewModel clienteVM)
        {
            var validacao = new ClienteValidador().Validate(clienteVM);
            if (!validacao.IsValid)
                return validacao;

            var cliente = _mapper.Map<ClienteModel>(clienteVM);
            _clienteRepository.PostCriacao(cliente);

            var endereco = _mapper.Map<ClienteEnderecoModel>(clienteVM);
            endereco.ClienteId = cliente.ClienteId;
            _cliEnderecoRepo.PostCriacao(endereco);

            return validacao;
        }

        public bool PostExclusao(int id)
        {
            var res = _clienteRepository.GetOne(id);
            if(res != null) { 
                _clienteRepository.PostExclusao(res);
                return true;
            }
            return false;
        }

        public ValidationResult PutEdicao(ClienteViewModel clienteVM)
        {
            var validacao = new ClienteValidador().Validate(clienteVM);
            if (!validacao.IsValid)
                return validacao;

            var cliente = _mapper.Map<ClienteModel>(clienteVM);
            _clienteRepository.PutEdicao(cliente);

            var endereco = _mapper.Map<ClienteEnderecoModel>(clienteVM);
            _cliEnderecoRepo.PutEdicao(endereco);

            return validacao;
        }

        public ClienteViewModel ClienteParaClienteView(ClienteModel cliente)
        {
            var endereco = _cliEnderecoRepo.GetCliEnderecoByCliId(cliente);
            var info = _mapper.Map<ClienteViewModel>(cliente);
            info.Bairro = endereco.Bairro;
            info.Cep = endereco.Cep;
            info.ClienteId = endereco.ClienteId;
            info.Complemento = endereco.Complemento;
            info.EnderecoId = endereco.EnderecoId;
            info.Localidade = endereco.Localidade;
            info.Logradouro = endereco.Logradouro;
            info.Numero = endereco.Numero;
            info.Uf = endereco.Uf;
            info.VendedorId = cliente.VendedorId;
            return info;
        }
    }
}
