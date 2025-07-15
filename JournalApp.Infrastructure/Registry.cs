using JournalApp.Domain.Journal;
using JournalApp.Domain.User;
using JournalApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

#pragma warning disable CS8604 // Possible null reference argument.

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
            .Filter.ByExcluding(logEvent =>
                logEvent.Level == LogEventLevel.Warning &&
                logEvent.RenderMessage().Contains("Lucky Penny software MediatR"))
            .WriteTo.Console()
            .WriteTo.File(config.GetSection("Logging").GetValue<string>("Path"), rollingInterval: RollingInterval.Day)
            .CreateLogger();

        services.AddDbContext<JournalAppDbContext>(option =>
            option.UseSqlite(config.GetConnectionString("DefaultConnection")));

        services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddSerilog();
        });
        services.AddSingleton<IConfiguration>(config);
        services.AddSingleton<IJournalRepository, JournalRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}