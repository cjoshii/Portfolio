using System;
using Microsoft.Extensions.Options;

namespace Portfolio.Api.Options;

public sealed class AuthOptionsSetup : IConfigureOptions<AuthOptions>
{
    private const string SectionName = "Auth";
    private readonly IConfiguration configuration;

    public AuthOptionsSetup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Configure(AuthOptions options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
