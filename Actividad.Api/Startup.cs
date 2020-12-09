using Actividad.Api.Models;
using Actividad.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Actividad.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuracion) => this.Configuracion = configuracion;

        private IConfiguration Configuracion { get; }

        public void ConfigureServices(IServiceCollection servicios)
        {
            servicios.AddCors
            (o => o.AddPolicy
                (
                    "Permitidos",
                    b => b
                         .AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowAnyOrigin()
                )
            );

            servicios.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            servicios.AddScoped<IRepositorioEstacionamientos, RepositorioEstacionamientos>();
            servicios.AddControllers();

            servicios.AddSwaggerGen(o =>
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Actividad 15",
                    Version = "v1",
                    Description = "API privada de Actividad 15",
                    TermsOfService = new Uri("https://www.pichancha.com"),
                    Contact = new OpenApiContact {Name = "Pichancha Collective", Email = "Info@Pichancha.com", Url = new Uri("https://www.pichancha.com")},
                    License = new OpenApiLicense {Name = "MIT", Url = new Uri("https://www.pichancha.com")}
                })
            );

            servicios.AddDbContext<Contexto>(o => o.UseSqlServer(this.Configuracion.GetConnectionString("Remoto")));
        }

        public void Configure(IApplicationBuilder aplicacion, IWebHostEnvironment entorno)
        {
            if (entorno.IsDevelopment()) aplicacion.UseDeveloperExceptionPage();

            aplicacion.UseHttpsRedirection();

            aplicacion.UseRouting();

            aplicacion.UseCors("Permitidos");

            aplicacion.UseAuthorization();

            aplicacion.UseSwagger();

            aplicacion.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Versión 1");
                o.RoutePrefix = String.Empty;
            });

            aplicacion.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
