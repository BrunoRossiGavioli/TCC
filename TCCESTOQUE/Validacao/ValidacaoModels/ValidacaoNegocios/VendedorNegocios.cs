using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoModels.ValidacaoNegocios
{
    public class VendedorNegocios : AbstractValidator<VendedorModel>
    {
        public VendedorNegocios(IVendedorRepository vend)
        {
            RuleFor(a => a.Cpf).Must(cpf => vend.GetByCpf(cpf) == null).WithMessage(MensagensErroVendedor.CpfjaCadastrado);
            RuleFor(a => a.Email).Must(email => vend.GetByEmail(email) == null).WithMessage(MensagensErroVendedor.EmailJaCadastrado);
            RuleFor(a => a.Telefone).Must(telefone => vend.GetByPhone(telefone) == null).WithMessage(MensagensErroVendedor.TelefoneJaCadastrado);
        }
    }
}
