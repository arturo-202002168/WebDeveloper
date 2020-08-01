using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebDeveloper.Core.Interfaces;
using WebDeveloper.Core.Services;
using WebDeveloper.Infra.Data;

namespace WebDeveloper.Api
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
            // Configurar el CORS
            services.AddCors(options =>
            {
                options.AddPolicy("All",
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            // Configurar el servicio del ChinookContext (new ChinookContext("cadena"))
            services.AddDbContext<IChinookContext, ChinookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ChinookConnection")));
            services.AddTransient<IReportesService, ReportesService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
