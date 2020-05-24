using System;
using System.Collections.Generic;
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
using Revivevzw.Business.Mappers;
using Revivevzw.Business.Repositories;
using Revivevzw.Business.Services;
using Revivevzw.DataAccess;

namespace Revivevzw.Api
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

      // Service injection
      services.AddTransient<IActivityService, ActivityService>();
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
