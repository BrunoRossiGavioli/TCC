using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TCCESTOQUE.AutoMapper;
using TCCESTOQUE.Data;
using TCCESTOQUE.Interfaces.Repository;
using TCCESTOQUE.Interfaces.Service;
using TCCESTOQUE.Repository;
using TCCESTOQUE.Service;

namespace TCCESTOQUE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuthentication")
                .AddCookie("CookieAuthentication", config =>
                {
                    config.Cookie.Name = "LoginUsuario";
                    config.LoginPath = "/Vendedor/Login";
                    config.AccessDeniedPath = "/Vendedor/LoginInvalido";
                });
            

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddDbContext<TCCESTOQUEContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("TCCESTOQUEContext")));

            services.AddMvc()
                .AddFluentValidation(c =>
                c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddScoped<IVendedorService, VendedorService>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IFornecedorService,FornecedorService>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Vendedor}/{action=Login}/{id?}");
            });
        }
    }
}
