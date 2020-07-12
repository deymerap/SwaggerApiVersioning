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
using Microsoft.OpenApi.Models;
using SwaggerApiVersioning.IServices;
using SwaggerApiVersioning.Models;
using SwaggerApiVersioning.Services;

namespace SwaggerApiVersioning
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
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IStudentService, StudentService>();

            services.AddControllers().
                AddXmlDataContractSerializerFormatters();
            services.AddMvcCore();
            //services.AddMvc();
            services.AddApiVersioning(config => 
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddSwaggerGen(config => 
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API v1 Titulo",
                    Description = "Descripcion API"
                });

                config.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "API v2 Titulo",
                    Description = "Descripcion API"
                });

                config.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "API v3 Titulo",
                    Description = "Descripcion API"
                });

                config.ResolveConflictingActions(a=> a.First());
                config.OperationFilter<RemoveVersionFromParameter>();
                config.DocumentFilter<ReplaceVersionWithExactValueInPath>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint($"/swagger/v1/swagger.json" ,"API v1");
                config.SwaggerEndpoint($"/swagger/v2/swagger.json" ,"API v2");
                config.SwaggerEndpoint($"/swagger/v3/swagger.json" ,"API v3");
            });



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
