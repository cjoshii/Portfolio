namespace Portfolio.Api.Options;

public sealed class ConnectionStringsOptions
{
    public string? Portfolio_db { get; init; }
    public string? Redis { get; init; }

}
public sealed class AuthOptions
{
    public string? Authority { get; init; }
    public string? Audience { get; init; }
}

public sealed class JwtOptions
{
    public string? Issuer { get; init; }
    public string? Audience { get; init; }
    public string? SigningKey { get; init; }
}

public sealed class MarketDataOptions
{
    public string? Provider { get; init; }
    public string? ApiKey { get; init; }
    public string? BaseUrl { get; init; }
}
