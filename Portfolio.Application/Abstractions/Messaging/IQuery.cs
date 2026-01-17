using MediatR;
using Portfolio.SharedKernel;

namespace Portfolio.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
