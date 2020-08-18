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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiAspNetCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                //c.DescribeAllEnumsAsStrings();
                //c.OperationFilter<SwaggerOperationFilters>();
                c.DescribeAllParametersInCamelCase();
                c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\Swagger.xml");
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Api Asp.Net Core 2.1",
                    Version = "v1",
                    Description = "WebApi de estudos de Asp.Net Core",
                    Contact = new Contact
                    {
                        Name = "Mattheus Soares",
                        Email = "tz_santos@hotmail.com",
                        Url = "https://github.com/MattheusSoares"
                    },
                    License = new License
                    {
                        Name = "MIT License",
                        Url = ""
                    }
                });

                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    In = "header",
                //    Description = "Para autenticar use a palavra 'Bearer' + (um espaço entre a palavra Bearer e o Token) + 'Token'",
                //    Name = "Authorization",
                //    Type = "apiKey"
                //});

                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    {"Bearer", new string[] { }},
                //});
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAspNetCore"); });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseAuthentication();
            app.UseMvc();
        }
    }
}