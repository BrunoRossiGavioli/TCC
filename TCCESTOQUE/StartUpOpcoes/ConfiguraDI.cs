﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            services.AddScoped<IFornecedorEnderecoRepository, FornecedorEnderecoRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IVendaItensService, VendaItensService>();
            services.AddScoped<IVendaItensRepository, VendaItensRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteEnderecoRepository, ClienteEnderecoRepository>();

            services.AddScoped<ISelectListService, SelectListService>();
        }
    }
}