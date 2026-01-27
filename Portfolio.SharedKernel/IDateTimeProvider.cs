namespace Portfolio.SharedKernel;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow { get; }
}
