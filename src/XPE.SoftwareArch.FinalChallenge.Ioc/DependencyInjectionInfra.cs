using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Repositories;
using XPE.SoftwareArch.FinalChallenge.Infra;
using XPE.SoftwareArch.FinalChallenge.Infra.ProductData;

namespace XPE.SoftwareArch.FinalChallenge.Ioc;

public static class DependencyInjectionInfra
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddEntityframeworkInfra(configuration)
                       .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }

    private static IServiceCollection AddEntityframeworkInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinalChallengeDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("FinalChallenge"), 
           b => b.MigrationsAssembly(typeof(FinalChallengeDbContext).Assembly.FullName)));

        return services;
    }
}
