
using Portfolio.SharedKernel;
using Portfolio.Application.Abstractions.Messaging;

namespace Portfolio.Application.Ping;

public sealed record PingCommand(string Message) : ICommand<PingResult>;

public sealed record PingResult(string Echo);

public sealed class PingCommandHandler : ICommandHandler<PingCommand, PingResult>
{
    public Task<Result<PingResult>> Handle(PingCommand request, CancellationToken cancellationToken)
        => Task.FromResult(Result<PingResult>.Success(new PingResult($"pong: {request.Message}")));
}
