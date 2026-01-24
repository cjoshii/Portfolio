using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Extensions;
using Portfolio.Application.System;

namespace Portfolio.Api.Modules;

public sealed class SystemModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiRoutes.V1Path("system"))
            .WithTags(Tags.System);

        group.MapGet("/ping", async (IMediator mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(new PingCommand(), ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("Ping");


        group.MapGet("/echo", async ([FromQuery] string arg, IMediator mediator, CancellationToken ct) =>
        {
            var result = await mediator.Send(new EchoCommand(arg), ct);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithName("Echo");
    }

}
