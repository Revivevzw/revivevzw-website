using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Revivevzw.Business.Mappers;
using Revivevzw.Business.Repositories;
using Revivevzw.Business.Services;
using Revivevzw.DataAccess;

namespace Revivevzw.Api
{
    public class Startup
    {
        private static readonly string[] allowedOrigins = new string[] { "142.93.108.123", "68.183.215.91" };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                        builder.WithOrigins(allowedOrigins)
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                        );
            });

            services.AddControllers();

            // DbContext injection
            services.AddDbContext<REVIVEContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Automapper injection
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ActivityMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Repository injection
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<IMissionRepository, MissionRepository>();

            // Service injection
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IMissionService, MissionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins(allowedOrigins)
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                );

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
