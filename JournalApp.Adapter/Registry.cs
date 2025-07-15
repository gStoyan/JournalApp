using JournalApp.Adapter.Services;
using JournalApp.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JournalApp.Adapter;

public static class Registry
{
    public static IServiceCollection AddAdapter(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IJournalService, JournalService>();
        return services;
    }
}