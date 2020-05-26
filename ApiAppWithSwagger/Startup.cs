using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ApiAppWithSwagger.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace ApiAppWithSwagger
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

            services.AddDbContext<ApiAppWithSwaggerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ApiAppWithSwaggerContext")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(ApiConstants.API_VERSION, new OpenApiInfo
                {
                    Title = ApiConstants.API_TITLE,
                    Version = ApiConstants.API_VERSION,
                    Description = ApiConstants.API_DESCRIPTION
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(opt => opt.SwaggerEndpoint(string.Concat("/swagger/", ApiConstants.API_VERSION, "/swagger.json"), ApiConstants.API_TITLE));
        }
    }
}
