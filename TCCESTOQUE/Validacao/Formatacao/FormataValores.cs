using System;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Formatacao
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
        return vendedorModel;
       }
    }
}
