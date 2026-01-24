using Microsoft.AspNetCore.Authentication.JwtBearer;
using Portfolio.Api.Extensions;
//using Microsoft.OpenApi.Models;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddOpenApiWithAuth(this IServiceCollection services)
    {
        services.AddOpenApi(static o =>
        {
            o.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
        });

        // services.AddSwaggerGen(static o =>
        // {
        //     o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

        //     // Temporarily commented out
        //     //var securityScheme = new OpenApiSecurityScheme
        //     //{
        //     //    Name = "JWT Authentication",
        //     //    Description = "Enter your JWT token in this field",
        //     //    In = ParameterLocation.Header,
        //     //    Type = SecuritySchemeType.Http,
        //     //    Scheme = JwtBearerDefaults.AuthenticationScheme,
        //     //    BearerFormat = "JWT"
        //     //};

        //     //o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

        //     //var securityRequirement = new OpenApiSecurityRequirement
        //     //{
        //     //    {
        //     //        new OpenApiSecurityScheme
        //     //        {
        //     //            Reference = new OpenApiReference
        //     //            {
        //     //                Type = ReferenceType.SecurityScheme,
        //     //                Id = JwtBearerDefaults.AuthenticationScheme
        //     //            }
        //     //        },
        //     //        []
        //     //    }
        //     //};

        //     //o.AddSecurityRequirement(securityRequirement);
        // });

        return services;
    }
}
