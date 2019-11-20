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
using Microsoft.OpenApi.Models;
using AutoMapper;

using EventManager.API.Domain.Repositories;
using EventManager.API.Domain.Services;
using EventManager.API.Persistence.Contexts;
using EventManager.API.Persistence.Repositories;
using EventManager.API.Services;

namespace EventManager.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("eventmanager-api-in-memory"); //new InMemoryDatabaseRoot(),ServiceLifetime.Transient
                options.EnableSensitiveDataLogging();
            });
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrganizerService, OrganizerService>();
            services.AddScoped<IOrganizerRepository, OrganizerRepository>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            
            services.AddSwaggerGen(c => 
                  c.SwaggerDoc("v1", new OpenApiInfo
                    {
                      Title = "Event manager API",
                      Version = "v1",
                      Contact = new OpenApiContact(){Name="Sofonias Araya", Url = new Uri("https://github.com/sofonias1")},
                      Description = "Simple RESTful API built with ASP.NET Core 3.0.",
                      License = new OpenApiLicense {Name = "MIT"},
                    }
                  ));
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
            // Enable middleware to serve generated Swagger as a Json endpoint
            app.UseSwagger();
            // Enable middleware to service swagger UI assets (html,js, css )
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
