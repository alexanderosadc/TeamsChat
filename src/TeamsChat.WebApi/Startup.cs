using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TeamsChat.SSMS;
using TeamsChat.SSMS.DbInitializer;
using TeamsChat.SSMS.Repository;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.WebApi.Mapper;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.MongoDbService.Context;
using TeamsChat.MongoDbService.UnitOfWork;
using TeamsChat.WebApi.Common;
using TeamsChat.DatabaseInterface;
using AspNetCoreRateLimit;

namespace TeamsChat.WebApi
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
            SSMSService(services);
            MongoDbServices(services);

            services.AddScoped<IControllerManager, ControllerManager>();
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();

            ConcurrentLimit(services);

            services.AddAutoMapper(
                typeof(AttachedFilesProfile),
                typeof(MessageGroupsProfile),
                typeof(MessagesProfile),
                typeof(UsersProfile),
                typeof(LogsProfile)
                );

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TeamsChat.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeamsChat.WebApi v1"));
            }

            try
            {
                var scopedFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopedFactory.CreateScope())
                {
                    var dbInitializer = scope.ServiceProvider.GetService<SSMSIDbInitializer>();
                    dbInitializer.Initialize();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MongoDbServices(IServiceCollection services)
        {
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<IMongoDbUnitOfWork, MongoDbUnitOfWork>();
            services.AddScoped<ILogsRepository, LogsRepository>();
        }
        private void SSMSService(IServiceCollection services)
        {
            services.AddDbContext<SSMSContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<SSMSIDbInitializer, SSMSDbInitializer>();
            services.AddScoped(typeof(ISSMSRepository<>), typeof(SSMSRepository<>));
            services.AddScoped(typeof(ISSMSUnitOfWork), typeof(SSMSUnitOfWork));
        }

        private void ConcurrentLimit(IServiceCollection services)
        {
            services.AddOptions();

            services.AddMemoryCache();

            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            services.AddInMemoryRateLimiting();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}
