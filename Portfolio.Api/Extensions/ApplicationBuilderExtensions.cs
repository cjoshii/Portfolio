using Portfolio.Api.Middleware;
using Scalar.AspNetCore;

namespace Portfolio.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        app.MapOpenApi();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "Portfolio API V1");
        });

        // Redoc
        // app.UseReDoc(options =>
        // {
        //     options.SpecUrl("/openapi/v1.json");
        // });

        // Scalar API Reference
        // app.MapScalarApiReference();

        return app;
    }

    public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextLoggingMiddleware>();

        return app;
    }
}
