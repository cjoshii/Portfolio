using Portfolio.Application.Abstractions.Messaging;
using Portfolio.SharedKernel;

namespace Portfolio.Application.System;

public sealed record EchoCommand(string Arg) : ICommand<EchoResponse>;

public sealed record EchoResponse(string Echo);

public class EchoCommandHandler : ICommandHandler<EchoCommand, EchoResponse>
{
    public async Task<Result<EchoResponse>> Handle(EchoCommand request, CancellationToken cancellationToken)
    {
        var response = new EchoResponse(request.Arg);
        return await Task.FromResult(Result.Success(response));
    }
}
