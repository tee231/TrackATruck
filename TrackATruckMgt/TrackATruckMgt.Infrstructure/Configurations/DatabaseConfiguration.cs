
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
using TrackATruckMgt.Core.Interfaces.Services;
using TrackATruckMgt.Data;

namespace TrackATruckMgt.Infrstructure.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");


            services.AddEntityFrameworkSqlServer()
            .AddDbContextPool<APPContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(connectionString);//.EnableSensitiveDataLogging();
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });
        }

        public static IHost DbMigration(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    scope.ServiceProvider.GetRequiredService<APPContext>().Database.Migrate();

                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetService<ILoggerService<IHost>>();
                    logger.LogError(ex);
                }
            }
            return host;
        }
    }


}
