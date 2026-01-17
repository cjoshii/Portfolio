using Microsoft.EntityFrameworkCore;

namespace Portfolio.Infrastructure.Data;

public sealed class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
    : DbContext(options)
{
    // Placeholder - we'll add DbSets later
}