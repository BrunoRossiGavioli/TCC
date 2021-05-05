using FluentValidation;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Models;
using TCCESTOQUE.Validacao.MensagensDeErro;

namespace TCCESTOQUE.Validacao.ValidacaoBusiness
{
    public class VendedorBusinessValidador : AbstractValidator<VendedorModel>
    {
        public VendedorBusinessValidador(IVendedorRepository vendRepo)
        {
            When(v => !string.IsNullOrEmpty(v.Cpf), () =>
            {
                When(v => vendRepo.GetByCpf(v.Cpf)?.VendedorId != v.VendedorId, () => {
                    RuleFor(a => a.Cpf).Must(cpf => vendRepo.GetByCpf(cpf) == null).WithMessage(MensagensErroVendedor.CpfjaCadastrado);
                });
            });

            When(v => vendRepo.GetByEmail(v.Email)?.VendedorId != v.VendedorId, () => 
            { 
                RuleFor(a => a.Email).Must(email => vendRepo.GetByEmail(email) == null).WithMessage(MensagensErroVendedor.EmailJaCadastrado);
            });

            When(v => !string.IsNullOrEmpty(v.Telefone), () => 
            {
                When(v => vendRepo.GetByTelefone(v.Telefone)?.VendedorId != v.VendedorId, () => {
                    RuleFor(a => a.Telefone).Must(telefone => vendRepo.GetByTelefone(telefone) == null).WithMessage(MensagensErroVendedor.TelefoneJaCadastrado);
                });
            });
        }
    }
}
