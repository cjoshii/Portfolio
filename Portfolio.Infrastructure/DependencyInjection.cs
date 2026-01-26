using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Domain.Users;
using Portfolio.Infrastructure.Persistance;

namespace Portfolio.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<PortfolioDbContext>("portfolio-db");

        builder.Services.AddIdentityCore<ApplicationUser>()
            .AddRoles<Microsoft.AspNetCore.Identity.IdentityRole<Guid>>()
            .AddEntityFrameworkStores<PortfolioDbContext>();

        return builder.Services;
    }
}
