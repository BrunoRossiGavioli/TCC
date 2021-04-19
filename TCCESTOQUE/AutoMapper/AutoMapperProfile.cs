using AutoMapper;
using TCCESTOQUE.Models;
using TCCESTOQUE.ViewModel;

namespace TCCESTOQUE.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FornecedorEnderecoViewModel, FornecedorModel>();
            CreateMap<FornecedorEnderecoViewModel, FornecedorEnderecoModel>();
            
            CreateMap<FornecedorEnderecoModel, FornecedorEnderecoViewModel>();
            CreateMap<FornecedorModel, FornecedorEnderecoViewModel>();
            
            CreateMap<VendaViewModel, VendaModel>();
            CreateMap<VendaViewModel, VendaItensModel>();

            CreateMap<ClienteViewModel, ClienteModel>();
            CreateMap<ClienteViewModel, ClienteEnderecoModel>();

            CreateMap<ClienteModel, ClienteViewModel>();
            CreateMap<ClienteEnderecoModel, ClienteViewModel>();
        }
    }
}
