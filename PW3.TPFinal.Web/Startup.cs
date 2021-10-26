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
using PW3.TPFinal.Servicios;
using PW3.TPFinal.Servicios.Contratos;
using PW3.TPFinal.Web.Middleware;

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

            // El mismo para todo el request;
            //services.AddScoped<IEventoServicio, EventoServicio>();

            //// Uno para cada instancia que la requiera;
            //services.AddTransient<IEventoServicio, EventoServicio>();

            //// El mismo para todo sin morir.
            //services.AddSingleton<IEventoServicio, EventoServicio>();

            //Configuro Session
            services.AddSession(options =>
            {
                options.Cookie.Name = "Session";
                options.IdleTimeout = TimeSpan.FromSeconds(1200);
            });


            // Configuro Repositorios
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IRecetaRepositorio, RecetaRepositorio>();
            services.AddScoped<ITipoRecetaRepositorio, TipoRecetaRepositorio>();

            // Configuro Servicios
            services.AddScoped<IEventoServicio, EventoServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<ICocineroServicio, CocineroServicio>();
            services.AddScoped<IComensalServicio, ComensalServicio>();
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
                app.UseExceptionHandler("/Evento/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();


            ConfigurarMiddleware(app);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Evento}/{action=Index}/{id?}");
            });
        }

        private void ConfigurarMiddleware(IApplicationBuilder app)
        {
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/Cocinero", StringComparison.InvariantCultureIgnoreCase),
                        app =>
                        {
                            app.UseMiddleware<CocinerosMiddleware>();
                        });

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/Comensal", StringComparison.InvariantCultureIgnoreCase),
                        app =>
                        {
                            app.UseMiddleware<ComensalesMiddleware>();
                        });

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/Usuario", StringComparison.InvariantCultureIgnoreCase),
             app =>
             {
                 app.UseMiddleware<UsuarioMiddleware>();
             });
        }
    }
}
