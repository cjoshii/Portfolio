using System;
using MediatR;
using Microsoft.Extensions.Logging;
using Portfolio.SharedKernel.Result;
using Serilog.Context;

namespace Portfolio.Application.Abstractions.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
 : IPipelineBehavior<TRequest, TResponse>
 where TRequest : class
 where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        logger.LogInformation("Handling request {RequestName}", requestName);

        TResponse response = await next(cancellationToken);

        if (response.IsSuccess)
        {
            logger.LogInformation("Request {RequestName} handled successfully", requestName);
        }
        else
        {
            using (LogContext.PushProperty("Error", response.Error, true))
            {
                logger.LogError("Request {RequestName} failed with error", requestName);
            }
        }

        return response;
    }
}
