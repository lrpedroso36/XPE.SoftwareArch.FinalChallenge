using Microsoft.Extensions.DependencyInjection;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Absctrations;

namespace XPE.SoftwareArch.FinalChallenge.Ioc;

public static class DependencyInjectionApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductUseCase, ProductUseCase>();
        return services;
    }
}
