using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Revivevzw.Business.Mappers;
using Revivevzw.Business.Repositories;
using Revivevzw.Business.Services;
using Revivevzw.DataAccess;

namespace Revivevzw.Api
{
    public class Startup
    {
        //Scaffold-DbContext "Server=tcp:revive.database.windows.net,1433;Database=REVIVE;User ID=ReviveAdmin;Password=ReviveDocters8!;" Microsoft.EntityFrameworkCore.SqlServer -force

        public readonly string WebOriginPolicy = "webOriginPolicy";

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
                //options.AddPolicy(name: WebOriginPolicy, builder =>
                //        builder.WithOrigins("https://revivevzw.netlify.app", "165.22.65.139", "157.230.103.136"));
                options.AddPolicy(name: WebOriginPolicy, builder =>
                        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers();

            // DbContext injection
            services.AddDbContext<REVIVEContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            // Automapper injection
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ActivityMapper());
                mc.AddProfile(new MissionMapper());
                mc.AddProfile(new SponsorMapper());
                mc.AddProfile(new SplashMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Repository injection
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<IMissionRepository, MissionRepository>();
            services.AddTransient<ISponsorRepository, SponsorRepository>();
            services.AddTransient<ISplashRepository, SplashRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            // Service injection
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IMissionService, MissionService>();
            services.AddTransient<ISponsorService, SponsorService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ISplashService, SplashService>();
            services.AddTransient<IPersonService, PersonService>();
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

            app.UseCors(WebOriginPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
