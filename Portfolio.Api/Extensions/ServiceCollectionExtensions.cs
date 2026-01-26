using Mapster;
using MapsterMapper;
using Portfolio.Api.Extensions;
using Portfolio.Api.Mapping;
using Portfolio.Api.Options;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddOpenApiWithAuth(this IServiceCollection services)
    {
        services.AddOpenApi(static o =>
        {
            o.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
        });
        return services;
    }

    internal static IServiceCollection AddMapper(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(typeof(ApiMappingConfig).Assembly);

        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    internal static IServiceCollection ConfigureSettingsOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<ConnectionStringsOptionsSetup>();
        services.ConfigureOptions<AuthOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<MarketDataOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        return services;
    }

}
