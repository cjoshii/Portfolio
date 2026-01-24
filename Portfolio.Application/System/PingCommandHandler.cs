
using Portfolio.SharedKernel;
using Portfolio.Application.Abstractions.Messaging;

namespace Portfolio.Application.System;

public sealed record PingCommand() : ICommand<string>;

public sealed class PingCommandHandler : ICommandHandler<PingCommand, string>
{
    public async Task<Result<string>> Handle(PingCommand request, CancellationToken cancellationToken = default)
        => await Task.FromResult(Result.Success("pong"));
}
