using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PW3.TPFinal.Comun.Configuracion;
using PW3.TPFinal.Negocio.Servicios;
using PW3.TPFinal.Negocio.Servicios.Contratos;
using PW3.TPFinal.Repositorio.Contratos;
using PW3.TPFinal.Repositorio.Data;
using PW3.TPFinal.Repositorio.Implementaciones;

namespace PW3.TPFinal.WebAPI
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

            services.AddControllers();
            services.AddCors();
            services.AddOptions();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PW3.TPFinal.WebAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },

                            new string[] {}
                    }
                });
            });

            this.AgregarJWTAutenticacion(services);

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
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PW3.TPFinal.WebAPI v1"));
            }

            app.UseCors(c => { c.AllowAnyOrigin(); c.AllowAnyHeader(); c.AllowAnyMethod(); });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AgregarJWTAutenticacion(IServiceCollection services)
        {
            var tokenSettingSection = this.Configuration.GetSection("JWTConfig");
            var tokenSettings = tokenSettingSection.Get<JWTConfiguracion>();
            var secretKey = Encoding.ASCII.GetBytes(tokenSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;                
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
