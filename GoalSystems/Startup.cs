using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoalSystems.Data;
using GoalSystems.Models;

namespace GoalSystems
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
            services.AddControllers();

            services.AddDbContext<GoalSystemsContext>(options =>
                    options.UseInMemoryDatabase(Configuration.GetConnectionString("GoalSystemsContext")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "GoalSystems API",
                    Description = "API prueba GoalSystems"
                });
            });

            //services.AddDbContext<GoalSystemsContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("GoalSystemsContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoalSystems API");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<GoalSystemsContext>();
            InitialData(context);
        }

        public static void InitialData(GoalSystemsContext context)
        {
            #region Alta datos iniciales

            //return new List<Incidencia>();
            Empresa empresa = new Empresa()
            {
                Id = 1,
                Nombre = "Mutiny",
                FechaAlta = DateTime.Now
            };

            Empleado empleado = new Empleado()
            {
                Id = 1,
                IdEmpresa = 1,
                Nombre = "Federico",
                Apellidos = "García Lorca",
                FechaAlta = DateTime.Now
            };

            Incidencia incidencia = new Incidencia()
            {
                Id = 1,
                IdEmpleado = 1,
                Descripcion = "Prueba incidencia",
                FechaAlta = DateTime.Now
            };

            Tarea tarea = new Tarea()
            {
                Id = 1,
                IdEmpleado = 1,
                Descripcion = "Prueba tarea",
                FechaAlta = DateTime.Now
            };

            context.Empresa.Add(empresa);
            context.Empleado.Add(empleado);
            context.Incidencia.Add(incidencia);
            context.Tarea.Add(tarea);

            context.SaveChanges();

            #endregion
        }
    }
}
