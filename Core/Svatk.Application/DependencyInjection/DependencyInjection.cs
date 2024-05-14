using Microsoft.Extensions.DependencyInjection;
using Svatk.Application.Services;
using Svatk.Domain.Interfaces.Services;

namespace Svatk.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.InitServices();
    }

    private static void InitServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}