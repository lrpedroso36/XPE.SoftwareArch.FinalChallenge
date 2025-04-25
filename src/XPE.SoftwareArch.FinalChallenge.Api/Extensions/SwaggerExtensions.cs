using Microsoft.OpenApi.Models;
using System.Reflection;

namespace XPE.SoftwareArch.FinalChallenge.Api.Extensions;

public static class SwaggerExtensions
{
    public static void AddCustomSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "XP Educação - Arquitetura de sofware",
                Description = "API responsável pela manutenção do domínio de produto."
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
