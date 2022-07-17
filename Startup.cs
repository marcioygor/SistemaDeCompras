using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaDeCompras.Data;
using Microsoft.EntityFrameworkCore;
using SistemaDeCompras.Repositories;
using SistemaDeCompras.Repositories.Interfaces;
using SistemaDeCompras.Models;
using Microsoft.AspNetCore.Identity; 

namespace SistemaDeCompras
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
            string mySqlConnection = Configuration.GetConnectionString("myConnection");
            services.AddDbContext<Context>(options => options.UseSqlServer(mySqlConnection));

              //Configurando o Identity
              services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<Context>() //--> Referenciar o arquivo de contexto. 
             .AddDefaultTokenProviders();
        
            //Configurando a injenção de dependência
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository,PedidoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //obtendo um carrinho de compra
            services.AddScoped(sp=>CarrinhoCompra.GetCarrinho(sp));

            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


             endpoints.MapControllerRoute(
                    name: "categoriaFiltro",
                    pattern: "Produto/{action}/{categoria?}",
                    defaults:new{Controller="Lanche", action="List"});
        });
    }
    }
}