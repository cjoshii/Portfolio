using Portfolio.Application.Abstractions.Messaging;
using Portfolio.SharedKernel.Result;

namespace Portfolio.Application.Portfolio;

public class CreatePortfolioCommandHandler : ICommandHandler<CreatePortfolioCommand, CreatePortfolioResponse>
{
    public async Task<Result<CreatePortfolioResponse>> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
    {
        var response = new CreatePortfolioResponse(Guid.NewGuid());
        Result<CreatePortfolioResponse> result = response;
        return await Task.FromResult(result);
    }
}
