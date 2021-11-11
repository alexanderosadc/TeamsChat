using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TeamsChat.SSMS.SeedFunctions;

namespace TeamsChat.SSMS.DbInitializer
{
    public class SSMSDbInitializer : SSMSIDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        private Seed _seed;
        public SSMSDbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SSMSContext>())
                {
                    try
                    {
                        context.Database.Migrate();

                        _seed = new Seed(context);
                        _seed.DevelopmentSeed();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
