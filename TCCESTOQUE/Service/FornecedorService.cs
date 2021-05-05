using AutoMapper;
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

        public FornecedorModel GetOne(int? id)
        {
            if (id == null)
                return null;

            return _fornecedorRepository.GetOne(id);
        }

        public bool PostExclusao(int id)
        {
            var res = _fornecedorRepository.GetOne(id);
            if (res != null)
            {
                _fornecedorRepository.PostExclusao(res);
                return true;
            }
            return false;
        }

        public FornecedorEnderecoViewModel GetEditFull(int? id)
        {
            return FeviewConvert(_fornecedorRepository.GetEdicao(id));
        }

        public ValidationResult PutEditFull(Guid id, FornecedorEnderecoViewModel feviewmodel)
        {
            var validador = ValidarFornecedorEnderecoViewModel(feviewmodel);
            if (validador.IsValid)
            {
                feviewmodel = FormataValores.FormataValoresFornecedorView(feviewmodel);
                var fornecedor = ConvertFornecedor(id, feviewmodel);
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

        public FornecedorModel ConvertFornecedor(Guid id, FornecedorEnderecoViewModel feViewModel)
        {
            var fornecedor = _mapper.Map<FornecedorModel>(feViewModel);
            var info = _fornecedorRepository.GetByEmail(feViewModel.Email);
            info.Cnpj = fornecedor.Cnpj;
            info.Email = fornecedor.Email;
            info.FornecedorId = id;
            info.NomeFantasia = fornecedor.NomeFantasia;
            info.RazaoSocial = fornecedor.RazaoSocial;
            info.Telefone = fornecedor.Telefone;
            info.VendedorId = fornecedor.VendedorId;
            return info;
        }
    }
}
