﻿using Microsoft.Extensions.DependencyInjection;
using TCCESTOQUE.AutoMapper;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Repository;
using TCCESTOQUE.Service;

namespace TCCESTOQUE.StartUpOpcoes
{
    public class ConfiguraDI
    {
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        public static void ConfigureServicesAndRepo(IServiceCollection services)
        {
            services.AddScoped<IVendedorService, VendedorService>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            //   services.AddScoped<IFornecedorEnderecoRepository, FornecedorEnderecoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();

            services.AddScoped<IVendaItensRepository, VendaItensRepository>();
            services.AddScoped<IVendaItensService, VendaItensService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<ISelectListRepository, SelectListRepository>();
        }
    }
}
