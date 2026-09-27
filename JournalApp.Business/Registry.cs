using JournalApp.Application.Commands.CreateUser;
using JournalApp.Business.Services;
using JournalApp.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JournalApp.Business;

public static class Registry
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));
        services.AddSingleton<IUserSessionContext, UserSessionContext>();
        return services;
    }
}