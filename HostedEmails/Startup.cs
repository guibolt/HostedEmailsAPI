using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostedEmails.Entities;
using HostedEmails.HostedServices;
using HostedEmails.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HostedEmails
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
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hosted Emails Web Api",
                    Version = "v1",
                    Description = "Api para testar o recurso de mandar emails periodicamente",
                    Contact = new OpenApiContact
                    {
                        Name = "Guilherme dos Reis",
                        Url = new Uri("https://guibolt.github.io/")
                    },
                });

            });

            services.AddControllers();

            //repo 
            services.AddSingleton<IRepositorio, Repositorio.Repositorio>();

            //services

            services
               .AddHostedService<EnviarEmailsHostedService>();
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

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HostedEmails");
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
