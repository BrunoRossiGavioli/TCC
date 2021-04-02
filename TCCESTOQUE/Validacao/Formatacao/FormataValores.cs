using System;
using TCCESTOQUE.Models;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.Validacao.Formatacao
{
    public class FormataValores
    {
       public static VendedorModel FormataValoresVendedor(VendedorModel vendedorModel)
       {
        vendedorModel.Nome = vendedorModel.Nome.ToUpper().Trim();
        vendedorModel.Endereco = vendedorModel.Endereco.ToUpper().Trim();
        vendedorModel.Cpf = vendedorModel.Cpf.Trim();
        vendedorModel.Telefone = vendedorModel.Telefone.Trim();
        vendedorModel.Email = vendedorModel.Email.Trim();
        vendedorModel.Senha = SecurityService.Criptografar(vendedorModel.Senha);
        return vendedorModel;
       }
    }
}
