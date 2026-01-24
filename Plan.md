# PHASE 0 — Solution & Aspire setup (Day 0)

## ✅ 0.1 Create Aspire solution

```
dotnet new aspire-starter -n PortfolioApp
```

Projects you should have:

- PortfolioApp.AppHost
- PortfolioApp.ServiceDefaults
- PortfolioApp.Api

## ✅ 0.2 Add infrastructure to AppHost

In AppHost:

- Add Postgres
- Add Redis
- Wire them to the API

```csharp
var postgres = builder.AddPostgres("postgres");
var redis = builder.AddRedis("redis");

builder.AddProject<Projects.PortfolioApp_Api>("api")
    .WithReference(postgres)
    .WithReference(redis);
```

✅ Aspire now controls infra.

# PHASE 1 — API skeleton & cross-cutting concerns

## ✅ 1.1 Configure API baseline

In Program.cs:

- Carter
- MediatR
- Mapster
- FluentValidation
- SignalR
- Health checks
- No business logic yet.

## ✅ 1.2 Structured logging (plug-and-play)

- Add Serilog
- Enrich with correlation IDs
- Console sink only for now
- Later you can swap sinks without touching business code.

## ✅ 1.3 Options pattern

Create options for:

- Database
- Redis
- Auth
- Market data provider (even if mocked)

```csharp
builder.Services.Configure<MarketDataOptions>(
    builder.Configuration.GetSection("MarketData"));
```

This future-proofs everything.

# PHASE 2 — Authentication & Authorization (foundation)

## ✅ 2.1 Auth model (minimal but extensible)

Entities:

**Account**

- Id
- Email
- PasswordHash
- CreatedAt

**Later:**

**Subscription**

- AccountId
- Tier (Free / Premium)

## ✅ 2.2 JWT authentication

- Access token
- Refresh token
- Claims include:
  - sub (AccountId)
  - tier (future)

## ✅ 2.3 Authorization policies

Even if all users have access now:

```csharp
policy.RequireClaim("tier", "Premium");
```

Don't use role checks directly in endpoints.

# PHASE 3 — Domain modeling (core business)

## ✅ 3.1 Core entities (DB truth)

- Portfolio
- Holding
- Transaction (flexible, nullable price)
- Trade (optional specialization)

**Key rule:**
DB stores truth, not derived values.

## ✅ 3.2 Transaction-first design

Everything that changes state:

- Buy (price optional)
- Sell (price optional)
- Add/Withdraw cash
- Add/Remove stock manually

This enables:

- Auditing
- Imports
- Corrections

# PHASE 4 — CQRS foundation

## ✅ 4.1 MediatR setup

- Commands for writes
- Queries for reads
- Pipeline behaviors:
  - Validation
  - Logging
  - Transaction scope

## ✅ 4.2 Feature-based folder structure

```
Portfolios/
 ├── CreatePortfolio/
 ├── AddCash/
 ├── ReportBuy/
 ├── ReportSell/
 ├── GetPortfolio/
 └── GetTransactions/
```

Each feature owns:

- Command / Query
- Handler
- Endpoint
- Validator

# PHASE 5 — Persistence & EF Core

## ✅ 5.1 EF Core with Postgres

- Migrations
- Explicit transactions for writes
- No lazy loading
- No leaking entities to API

## ✅ 5.2 Read models

Queries return DTOs, not entities.

Later you can:

- Add Dapper
- Add projections
- Without rewriting commands.

# PHASE 6 — Caching strategy (clean & swappable)

## ✅ 6.1 Cache abstraction

Create your own interface:

```csharp
public interface ICache
{
    Task<T?> Get<T>(string key);
    Task Set<T>(string key, T value, TimeSpan ttl);
}
```

Provide:

- Redis implementation
- Memory implementation
- Aspire decides which one runs.

✅
