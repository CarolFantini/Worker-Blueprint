using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Worker.Data;
using Worker.Interfaces;
using Worker.Repositories;
using Worker.Services;
using Worker.Services.Interfaces;
using Worker.Settings;

namespace Worker.Utils
{
    public static class InjectionContainer
    {
        public static IServiceCollection InfraInjection(this IServiceCollection services)
        {
            services.ConfigureSettings();
            services.RegisterServices();
            services.ConfigureDatabase();
            services.RegisterRepositories();

            return services;
        }

        private static IServiceCollection ConfigureSettings(this IServiceCollection services)
        {
            services.AddOptions<ConnectionStringsSettings>().BindConfiguration("ConnectionStrings");

            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICsvService, CsvService>();

            return services;
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
        {
            var connectionStringsSettings = services.BuildServiceProvider().GetRequiredService<IOptions<ConnectionStringsSettings>>().Value;

            var provider = connectionStringsSettings.Provider?.ToLower();

            if (provider == "sqlserver" || provider == "postgresql")
            {
                services.AddDbContext<RelationalDbContext>(options =>
                {
                    if (provider == "sqlserver")
                        options.UseSqlServer(connectionStringsSettings.Database,
                            b => b.MigrationsAssembly(typeof(InjectionContainer).Assembly.FullName));
                    else
                        options.UseNpgsql(connectionStringsSettings.Database,
                            b => b.MigrationsAssembly(typeof(InjectionContainer).Assembly.FullName));
                }, ServiceLifetime.Scoped);

                services.AddScoped<IDatabaseContext>(sp =>
                    sp.GetRequiredService<RelationalDbContext>());
            }
            else if (provider == "mongodb")
            {
                services.AddSingleton<IMongoClient>(sp =>
                    new MongoClient(connectionStringsSettings.Database));

                services.AddScoped<IMongoDatabase>(sp =>
                {
                    var client = sp.GetRequiredService<IMongoClient>();
                    return client.GetDatabase(connectionStringsSettings.MongoDbName);
                });

                services.AddScoped<IDatabaseContext, MongoDbContext>();
            }
            else
            {
                throw new Exception("Unsupported database provider!");
            }

            return services;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();

            return services;
        }
    }
}
