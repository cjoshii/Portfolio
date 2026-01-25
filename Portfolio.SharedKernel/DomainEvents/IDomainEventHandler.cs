using MediatR;

namespace Portfolio.SharedKernel.DomainEvents;

public interface IDomainEventHandler<in T> : INotificationHandler<T> where T : IDomainEvent
{
}
