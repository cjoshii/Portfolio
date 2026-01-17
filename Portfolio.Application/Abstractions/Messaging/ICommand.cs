using MediatR;
using Portfolio.SharedKernel;

namespace Portfolio.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;