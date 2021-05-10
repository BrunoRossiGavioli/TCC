using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TCCESTOQUE.Controllers;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.Formatacao;
using TCCESTOQUE.Validacao.ValidacaoBusiness;
using TCCESTOQUE.Validacao.ValidacaoModels;
using TCCESTOQUE.ValidadorVendedor;

namespace TCCESTOQUE.Service
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _vendedorRepository;
        private readonly ICarrinhoRepository _carrinhoRepo;
        public VendedorService(IVendedorRepository vendedorRepository, ICarrinhoRepository carrinhoRepo)
        {
            _vendedorRepository = vendedorRepository;
            _carrinhoRepo = carrinhoRepo;
        }
        public ICollection<VendedorModel> GetAll(Guid vendedorId)
        {
            return _vendedorRepository.GetAll(vendedorId);
        }

        public VendedorModel GetOne(Guid? id)
        {
            if (id == null)
                return null;

            return _vendedorRepository.GetOne(id);
        }

        public VendedorModel GetEdicao(Guid? id)
        {
            return _vendedorRepository.GetEdicao(id);
        }

        public ValidationResult PostCriacao(VendedorModel vendedorModel)
        {
            var validacao = ValidarVendedor(vendedorModel);
            if (validacao.IsValid) { 
                vendedorModel = FormataValores.FormataValoresVendedor(vendedorModel);
                _vendedorRepository.PostCriacao(vendedorModel);
                _carrinhoRepo.PostCriacao(new CarrinhoModel() { VendedorId = vendedorModel.VendedorId });
            }
            return validacao;
        }

        public ValidationResult PutEdicao(Guid id, VendedorModel vendedorModel)
        {
            var validacao = ValidarVendedor(vendedorModel);
            if (validacao.IsValid)
            {
                var vendedor = ConvertVendedor(vendedorModel);
                vendedor = FormataValores.FormataValoresVendedor(vendedor);
                _vendedorRepository.PutEdicao(vendedor);
            }
            return validacao;
        }

        public bool PostExclusao(Guid id)
        {
            var res = _vendedorRepository.GetOne(id);
            if (res == null)
                return false;

            res.Inativo = true;
            _vendedorRepository.PutEdicao(res);
            return true;
        }

        public object PostLogin(VendedorModel vendedorModel)
        {
            var validacao = new LoginValidador(_vendedorRepository, vendedorModel).Validate(vendedorModel);
            if (!validacao.IsValid)
                return validacao;

            var vendedor = _vendedorRepository.GetByEmail(vendedorModel.Email);
            return _vendedorRepository.PostLogin(vendedor);
        }

        private ValidationResult ValidarVendedor(VendedorModel vendedor)
        {
            var validacao = new VendedorValidador().Validate(vendedor);
            if (!validacao.IsValid)
                return validacao;

            var validacaoBusiness = new VendedorBusinessValidador(_vendedorRepository).Validate(vendedor);
            if (!validacaoBusiness.IsValid)
                return validacaoBusiness;

            return validacao;
        }

        private VendedorModel ConvertVendedor(VendedorModel vendedorModel)
        {
            var vendedor = _vendedorRepository.GetByCpf(vendedorModel.Cpf);
            vendedor.Cpf = vendedorModel.Cpf;
            vendedor.Email = vendedorModel.Email;
            vendedor.DataNascimento = vendedor.DataNascimento;
            vendedor.Nome = vendedorModel.Nome;
            vendedor.Senha = vendedorModel.Senha;
            vendedor.Telefone = vendedorModel.Telefone;
            return vendedor;
        }
    }
}
