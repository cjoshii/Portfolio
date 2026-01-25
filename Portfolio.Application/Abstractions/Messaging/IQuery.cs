using MediatR;
using Portfolio.SharedKernel.Result;

namespace Portfolio.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
