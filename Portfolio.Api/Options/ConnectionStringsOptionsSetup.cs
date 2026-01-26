using Microsoft.Extensions.Options;

namespace Portfolio.Api.Options;

public sealed class ConnectionStringsOptionsSetup : IConfigureOptions<ConnectionStringsOptions>
{
    private const string SectionName = "ConnectionStrings";
    private readonly IConfiguration configuration;

    public ConnectionStringsOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(ConnectionStringsOptions options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
