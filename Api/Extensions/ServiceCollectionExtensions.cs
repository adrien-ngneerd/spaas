using Asp.Versioning;

namespace Ngneerd.PowerplantCodingChallenge.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpLogging(_ => { });
        services.AddControllers();
        services.AddApiVersioning(x =>
        {
            // TODO: Configure via appsettings
            x.DefaultApiVersion = new ApiVersion(0, 1);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
        });
        return services;
    }
}