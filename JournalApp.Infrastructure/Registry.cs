using JournalApp.Domain.User;
using JournalApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JournalApp.Infrastructure;

public static class Registry
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<JournalAppDbContext>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}