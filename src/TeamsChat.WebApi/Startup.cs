using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TeamsChat.Data;
using TeamsChat.Data.DbInitializer;
using TeamsChat.Data.Repository;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.WebApi.Mapper;

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
            services.AddDbContext<TeamsChatContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddAutoMapper(
                typeof(AttachedFilesProfile),
                typeof(MessageGroupsProfile),
                typeof(MessagesProfile),
                typeof(UsersProfile)
                );

            services.AddControllers();
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
                    var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
                    dbInitializer.Initialize();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
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
