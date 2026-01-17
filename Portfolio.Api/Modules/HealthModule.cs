using Carter;

namespace Portfolio.Api.Modules;

public class HealthModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // group endpoints under /health and tag them as "Health"
        var group = app.MapGroup("/health")
                       .WithTags("Health");

        group.MapGet("/", () => Results.Ok(new { status = "ok" }))
             .WithName("HealthCheck");

        group.MapGet("/ready", () => Results.Ok(new { status = "ready" }))
             .WithName("ReadinessCheck");
    }
}
