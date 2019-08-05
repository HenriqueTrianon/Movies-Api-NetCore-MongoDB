using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Movies.Domain.Mapper;
using Movies.Infra.IOC.Containers;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;

namespace Movies.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                        new Info
                        {
                                Title = "Movies API",
                                Version = "v1",
                                Description = "Example of an API using ASP.NET Core Good practices",
                                Contact = new Contact
                                {
                                        Name = "Henrique Trianon de Moraes Souza",
                                        Url = "https://github.com/HenriqueTrianon"
                                }
                        });
                var caminhoAplicacao = AppDomain.CurrentDomain.BaseDirectory;
                var nomeAplicacao = AppDomain.CurrentDomain.FriendlyName;
                var caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
                c.IncludeXmlComments(caminhoXmlDoc);
            });
            var builder = new ContainerBuilder();
            builder.Populate(services);
            ApplicationContainer = MovieContainerBuilder.Build(builder);

            Mapper.Initialize(cfg => cfg.AddProfile<MoviesDomainProfile>());
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                ILoggerFactory loggerFactory,
                IApplicationLifetime appLifetime,
                IHostingEnvironment env)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "Movie API");
            });
            app.UseMvc(routes => { routes.MapRoute("default", "{controller=Movies}/{action=Index}/{id?}"); });
        }
    }
}
