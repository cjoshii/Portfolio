using Portfolio.Application.Abstractions.Messaging;
using Portfolio.SharedKernel.Result;

namespace Portfolio.Application.System;

public class EchoCommandHandler : ICommandHandler<EchoCommand, EchoResponse>
{
    public async Task<Result<EchoResponse>> Handle(EchoCommand request, CancellationToken cancellationToken)
    {
        var response = new EchoResponse(request.Message);
        Result<EchoResponse> result = response;
        return await Task.FromResult(result);
    }
}
