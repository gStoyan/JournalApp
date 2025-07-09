using JournalApp.Domain.User;
using JournalApp.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace JournalApp.Infrastructure;

public static class Registry
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Log_SerilogDemo.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddSerilog();
        });
        services.AddSingleton<IConfiguration>(config);
        services.AddDbContext<JournalAppDbContext>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}