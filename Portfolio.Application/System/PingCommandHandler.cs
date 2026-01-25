
using Portfolio.SharedKernel.Result;
using Portfolio.Application.Abstractions.Messaging;

namespace Portfolio.Application.System;

public sealed class PingCommandHandler : ICommandHandler<PingCommand, string>
{
    public async Task<Result<string>> Handle(PingCommand request, CancellationToken cancellationToken = default)
    {
        // Result<string> result = "pong";
        return await Task.FromResult(Result.Success("pong"));
    }
}
