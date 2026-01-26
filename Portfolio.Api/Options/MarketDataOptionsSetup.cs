using Microsoft.Extensions.Options;

namespace Portfolio.Api.Options;

public sealed class MarketDataOptionsSetup : IConfigureOptions<MarketDataOptions>
{
    private const string SectionName = "MarketData";
    private readonly IConfiguration configuration;

    public MarketDataOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(MarketDataOptions options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
