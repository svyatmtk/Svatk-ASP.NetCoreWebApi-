using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Svatk.DAL.Repositories;
using Svatk.Domain.Entity;
using Svatk.Domain.Interfaces.Repository;

namespace Svatk.DAL.DependencyInjection;

public static class DependencyInjection
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresSql");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.InitRepository();
    }

    private static void InitRepository(this IServiceCollection services)
    {
        services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
        services.AddScoped<IBaseRepository<Profile>, BaseRepository<Profile>>();
        services.AddScoped<IBaseRepository<Balance>, BaseRepository<Balance>>();
        services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
    }
}