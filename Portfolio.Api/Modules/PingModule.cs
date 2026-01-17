using Carter;
using MediatR;
using Portfolio.Application.Ping;

namespace Portfolio.Api.Modules;

public sealed class PingModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/ping")
            .WithTags("Ping");

        group.MapGet("/", async (string message, IMediator mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(new PingCommand(message), ct);

            return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.BadRequest(result.Error);
        })
        .WithName("Ping");

    }
}
