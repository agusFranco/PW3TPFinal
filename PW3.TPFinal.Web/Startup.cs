using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Repositorio.Implementaciones;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Web.Filters;
using PW3.TPFinal.Negocio.Servicios;
using PW3.TPFinal.Comun.Configuracion;

namespace PW3.TPFinal.Web
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
            services.AddDbContext<_20212C_TPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TPFinalContext")));

            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.Cookie.Name = "Session";
                options.IdleTimeout = TimeSpan.FromSeconds(1200);
            });

            // Filtros
            services.AddScoped<EsCocinero>();
            services.AddScoped<EsComensal>();
            services.AddScoped<NoEstaLogeado>();
            services.AddScoped<Logeado>();

            // Configuro Repositorios
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IRecetaRepositorio, RecetaRepositorio>();
            services.AddScoped<ITipoRecetaRepositorio, TipoRecetaRepositorio>();
            services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
            services.AddScoped<ICalificacionRepositorio, CalificacionRepositorio>();

            // Configuro Servicios
            services.AddScoped<IEventoServicio, EventoServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<ICocineroServicio, CocineroServicio>();
            services.AddScoped<IComensalServicio, ComensalServicio>();

            services.Configure<JWTConfiguracion>(options => this.Configuration.GetSection("JWTConfig").Bind(options));
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
            app.UseAuthorization();
            app.UseSession();    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Evento}/{action=Index}/{id?}");
            });
        } 
    }
}
