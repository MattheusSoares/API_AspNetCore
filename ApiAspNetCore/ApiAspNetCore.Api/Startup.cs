using ApiAspNetCore.Api.Swagger;
using ApiAspNetCore.Dominio.Handlers;
using ApiAspNetCore.Dominio.Repositorio;
using ApiAspNetCore.Infra.Data.Repositorio;
using ApiAspNetCore.Infra.Data.Settings;
using LSCode.ConexoesBD.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;

namespace ApiAspNetCore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region AppSettings
            services.Configure<SettingsInfraData>(options => Configuration.GetSection("SettingsInfraData").Bind(options));
            //services.Configure<SettingsAPI>(options => Configuration.GetSection("SettingsAPI").Bind(options));
            #endregion

            #region DataContext
            services.AddScoped<DbContext>();
            #endregion

            #region Repositorios
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            #endregion

            #region Handler
            services.AddTransient<UsuarioHandler, UsuarioHandler>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                //c.DescribeAllEnumsAsStrings();
                c.OperationFilter<SwaggerOperationFilters>();
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

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Para autenticar use a palavra 'Bearer' + (um espaço entre a palavra Bearer e o Token) + 'Token'",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                });
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