using Carter;
using MapsterMapper;
using MediatR;
using Portfolio.Api.Contracts.Portfolio;
using Portfolio.Api.Extensions;
using Portfolio.Application.Portfolio;
using Portfolio.SharedKernel.Result;

namespace Portfolio.Api.Modules.Portfolio;

public class PortfoliosModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(ApiRoutes.V1Path("portfolio"))
            .WithTags(Tags.Portfolio);

        group.MapPost("/", async (CreatePortfolioRequest request, IMapper mapper, IMediator mediator, CancellationToken ct) =>
        {
            var command = mapper.Map<CreatePortfolioCommand>(request);
            var result = await mediator.Send(command, ct);
            return result.Match(
            response => Results.CreatedAtRoute(
                "GetPortfolioById",
                new { id = response.PortfolioId },
                response),
            CustomResults.Problem);
        })
        .WithSummary("Create a portfolio")
        .WithDescription("Creates a new portfolio for the authenticated user.")
        .WithName("CreatePortfolio")
        .Accepts<CreatePortfolioRequest>("application/json")
        .Produces<CreatePortfolioResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator, CancellationToken ct) =>
        {
            Result<string> result = "Here is your portfolio!";
            return result.Match(Results.Ok,
                CustomResults.Problem);
        }).WithName("GetPortfolioById")
        .WithSummary("Get portfolio by ID")
        .WithDescription("Retrieves a portfolio by its unique identifier.")
        .Produces<string>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
