using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PW3.TPFinal.Comun.Configuracion;
using PW3.TPFinal.Negocio.Servicios;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Repositorio.Implementaciones;
using PW3.TPFinal.Web.Filters;

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

            services.AddWebOptimizer((pipeline =>
            {
                pipeline.MinifyJsFiles("js/**/*.js");
                pipeline.MinifyCssFiles("css/**/*.css");

                pipeline.AddCssBundle(
                    "/css/bundle.css",
                    "template/plugins/fontawesome-5.15.2/css/all.min.css",
                    "template/plugins/fontawesome-5.15.2/css/fontawesome.min.css",
                    "template/plugins/animate/animate.css",
                    "template/plugins/menuzord/css/menuzord.css",
                    "template/plugins/menuzord/css/menuzord-animations.css",
                    "template/plugins/fancybox/jquery.fancybox.min.css",
                    "template/css/star.css",
                    "css/**/*.css");

                pipeline.AddJavaScriptBundle(
                    "/js/bundle.js",
                    "template/plugins/jquery/jquery.min.js",
                    "template/plugins/bootstrap/js/bootstrap.bundle.min.js",
                    "template/plugins/menuzord/js/menuzord.js",
                    "template/plugins/fancybox/jquery.fancybox.min.js",
                    "template/plugins/lazyestload/lazyestload.js",
                    "template/plugins/smoothscroll/SmoothScroll.js",
                    "template/js/star.js",
                    "js/site.js");
            }));

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

            app.UseWebOptimizer();

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
