using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Roni.Pomodoro.Api.Controllers;
using Roni.Pomodoro.Persistence;
using Roni.Pomodoro.Persistence.Entities;
using Roni.Pomodoro.Services;
using Roni.Pomodoro.Shared;

namespace Roni.Pomodoro.Api
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
            services.AddScoped<ILogger, Logger<TimeBlocksController>>();
            services.ConfigurePersistenceServices(Configuration.GetConnectionString("PomodoroDb"));
            ConfigureAutoMapper(services);
            // Must be configured after automapper and persistence services
            services.AddScoped<ITimeBlockService, TimeBlockService>();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskBlock, TimeBlock>();
                cfg.CreateMap<TimeBlock, TaskBlock>();
            });

            services.AddSingleton<IMapper>(new Mapper(config));
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
        }
    }
}
