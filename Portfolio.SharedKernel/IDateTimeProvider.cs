namespace Portfolio.SharedKernel;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
