namespace Portfolio.Api.Contracts.Portfolio;

public sealed record CreatePortfolioRequest(
    string Name,
    string Description
);
