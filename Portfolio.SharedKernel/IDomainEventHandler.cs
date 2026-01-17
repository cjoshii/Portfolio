using MediatR;

namespace Portfolio.SharedKernel;

public interface IDomainEventHandler<in T> : INotificationHandler<T> where T : IDomainEvent
{
}
