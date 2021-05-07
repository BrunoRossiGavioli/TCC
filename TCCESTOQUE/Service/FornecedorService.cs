﻿using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoBusiness;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorEnderecoRepository _fornecedorEnderecoRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository,IFornecedorEnderecoRepository fornecedorEnderecoRepository ,IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorEnderecoRepository = fornecedorEnderecoRepository;
            _mapper = mapper;
        }

        public ICollection<FornecedorModel> GetAll()
        {
            return _fornecedorRepository.GetAll();
        }

        public FornecedorModel GetOne(Guid? id)
        {
            if (id == null)
                return null;

            return _fornecedorRepository.GetOne(id);
        }

        public object PostExclusao(Guid id)
        {
            var res = _fornecedorRepository.GetOne(id);
            if (res.Produtos.Count > 0)
                return "Não é possivel deletar esse fornecedor, ele tem produtos";
            if (res != null)
            {
                _fornecedorRepository.PostExclusao(res);
                return true;
            }
            return false;
        }

        public FornecedorEnderecoViewModel GetEditFull(Guid? id)
        {
            return FeviewConvert(_fornecedorRepository.GetEdicao(id));
        }

        public ValidationResult PutEditFull(Guid id, FornecedorEnderecoViewModel feviewmodel)
        {
            var validador = ValidarFornecedorEnderecoViewModel(feviewmodel);
            if (validador.IsValid)
            {
                feviewmodel = FormataValores.FormataValoresFornecedorView(feviewmodel);
                var fornecedor = ConvertFornecedor(feviewmodel);
                _fornecedorRepository.PutEdicao(fornecedor);

                var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);
                endereco.FornecedorId = fornecedor.FornecedorId;
                _fornecedorEnderecoRepository.PutEdit(endereco);
            }
            return validador;
        }

        public ValidationResult PostCadastroFull(FornecedorEnderecoViewModel feviewmodel)
        {
            var validador = ValidarFornecedorEnderecoViewModel(feviewmodel);

            if (validador.IsValid)
            {
                feviewmodel = FormataValores.FormataValoresFornecedorView(feviewmodel);
                var fornecedor = _mapper.Map<FornecedorModel>(feviewmodel);
                _fornecedorRepository.PostCriacao(fornecedor);
                
                var endereco = _mapper.Map<FornecedorEnderecoModel>(feviewmodel);
                endereco.FornecedorId = fornecedor.FornecedorId;
                _fornecedorEnderecoRepository.PostCadastro(endereco);
            }
            return validador;
        }

        public ValidationResult ValidarFornecedorEnderecoViewModel(FornecedorEnderecoViewModel feViewModel)
        {
            var validacao = new FornecedorEnderecoValidador().Validate(feViewModel);
            if (!validacao.IsValid)
                return validacao;

            var validacaoBusiness = new FornecedorEnderecoBusinessValidador(_fornecedorRepository).Validate(feViewModel);
            if (!validacaoBusiness.IsValid)
                return validacaoBusiness;

            return validacao;
        }

        public FornecedorEnderecoViewModel FeviewConvert(FornecedorModel fornecedor)
        {
            if (fornecedor == null)
                return null;

            var endereco = _fornecedorEnderecoRepository.GetEnderecoByFornecedorId(fornecedor);
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

        public FornecedorModel ConvertFornecedor(FornecedorEnderecoViewModel feViewModel)
        {
            var info = _fornecedorRepository.GetById(feViewModel.FornecedorId);
            info.Cnpj = feViewModel.Cnpj;
            info.Email = feViewModel.Email;
            info.FornecedorId = feViewModel.FornecedorId;
            info.NomeFantasia = feViewModel.NomeFantasia;
            info.RazaoSocial = feViewModel.RazaoSocial;
            info.Telefone = feViewModel.Telefone;
            info.VendedorId = feViewModel.VendedorId;
            return info;
        }
    }
}
