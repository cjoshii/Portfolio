using Portfolio.Application.Abstractions.Messaging;

namespace Portfolio.Application.Portfolio;

public sealed record CreatePortfolioCommand(string Name, string Description) : ICommand<CreatePortfolioResponse>;

public sealed record CreatePortfolioResponse(Guid PortfolioId);
