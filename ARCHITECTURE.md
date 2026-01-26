# Portfolio API – Architecture & Implementation Notes

> **Purpose**
>
> This document is the single source of truth for architectural decisions,
> technology choices, and implementation progress for the Portfolio API.
>
> It is intended to:
>
> - Preserve context across chats / sessions
> - Prevent architectural drift
> - Make future refactors intentional, not accidental

---

## High-level goals

- Cloud-native, scalable backend API
- Support Web (React/Angular) and iOS clients
- Clean architecture with strong boundaries
- Real-time portfolio valuation
- Extensible authentication & authorization (premium features later)

---

## Technology stack

### Platform

- **.NET 10**
- **ASP.NET Core**
- **Aspire** (AppHost orchestration, observability)

### API

- Minimal APIs
- **Carter** (`ICarterModule`)
- API versioning via URL path: `/api/v1`

### Architecture

- Clean architecture
- Vertical slices / feature-based folders
- CQRS with custom abstractions over MediatR

### Messaging / CQRS

- `ICommand`
- `ICommand<TResponse>`
- `IQuery<TResponse>`
- Handlers return `Result` / `Result<T>`
- MediatR is an implementation detail (can be removed later)

### Validation

- **FluentValidation**
- Executed via MediatR pipeline behavior
- Validation failures return `Result.Failure` (no exceptions)

### Mapping

- **Mapster**
- Mapping occurs at API boundary
- API DTOs → Application Commands/Queries
- Centralized mapping configuration
- No Application → API dependency

### Configuration & Options

- Options pattern via `IOptions<T>`
- Options bound from configuration sections
- Options classes:
  - Database
  - Redis
  - Auth
  - Jwt
  - MarketData

### Persistence

- **PostgreSQL**
- **EF Core**
- Migrations via `dotnet-ef`
- Identity tables + domain tables in same database

### Caching

- **HybridCache** (ASP.NET Core)
  - L1: in-memory
  - L2: Redis
- Redis also used for:
  - SignalR backplane
  - Latest stock prices

### Real-time

- **SignalR**
- Redis backplane for scale-out
- Group-based subscriptions:
  - by symbol
  - by portfolio

### Logging & Observability

- **Serilog** (host-level via `UseSerilog`)
- Structured logging (compact JSON file sink)
- Aspire dashboard + OpenTelemetry
- No hardcoded sinks in code

---

## Solution structure

Portfolio.Api
Portfolio.Application
Portfolio.Domain
Portfolio.Infrastructure
Portfolio.SharedKernel
Portfolio.AppHost
Portfolio.ServiceDefaults

---

## Layer responsibilities

### Portfolio.Api

- HTTP concerns only
- API DTOs (request/response)
- Routing, versioning, OpenAPI metadata
- Mapping DTO → Command/Query
- Result → HTTP mapping (ProblemDetails)
- Authentication/Authorization middleware

### Portfolio.Application

- Use cases (commands/queries)
- Business validation
- CQRS handlers
- No HTTP / JSON / ASP.NET dependencies

### Portfolio.Domain

- Core business concepts
- Entities, value objects, domain events
- No infrastructure concerns

### Portfolio.Infrastructure

- EF Core DbContext
- Identity stores
- Database migrations
- Redis, caching, external integrations

### Portfolio.SharedKernel

- Result pattern
- Error / ErrorType
- ValidationError
- Base Entity abstractions

---

## API design conventions

### Routing

- Versioned URLs: `/api/v1/...`
- Route groups per resource
- Named routes for GET-by-id

### Create endpoints

- `POST` returns **201 Created**
- Uses `Results.CreatedAtRoute`
- `Location` header points to GET-by-id

### Result handling

- Handlers return `Result` / `Result<T>`
- API converts Result → HTTP via `Match`
- Clients never see Result objects

---

## Authentication & Authorization (CLARIFIED)

### Approach

- **ASP.NET Core Identity**
- EF Core stores
- JWT-based authentication

### Features to support

- Registration
- Login
- Access token (short-lived)
- Refresh token (long-lived)
  - Stored hashed in DB
  - Rotation on refresh
  - Invalidation on logout
- Email verification
- Logout
- 2FA (authenticator + recovery codes)
- Policy-based authorization (premium features later)

### Account vs User decision

- **Default choice**: Identity user _is_ the Account
- Domain entities reference `AspNetUsers.Id`
- Can add a separate `AccountProfile` later if needed

---

## Domain concepts (planned)

- User (Identity)
- Portfolio
- Holding
- Transaction
  - Buy
  - Sell
  - AddCash
  - WithdrawCash
  - Manual add/remove stock
- MarketPrice (ephemeral, Redis-backed)

---

## Phases & status

### Phase 0 — Infrastructure & Repo Setup ✅ DONE

- SLNX solution
- CPM (`Directory.Packages.props`)
- `Directory.Build.props`
- Aspire AppHost
- Postgres + Redis resources

### Phase 1 — API Foundation ✅ DONE

- Minimal API + Carter
- CQRS abstractions
- Result pattern + Match
- Validation pipeline
- Mapster mapping
- CreatedAtRoute pattern
- OpenAPI metadata

### Phase 2A — Authentication & Identity 🔜 NEXT

- Identity DbContext
- Migrations
- JWT issuing
- Refresh token persistence
- Email confirmation
- 2FA scaffolding
- Auth policies

### Phase 2B — Portfolio Persistence 🔜 NEXT

- EF Core entities
- DbContext
- Real CreatePortfolio handler
- Account scoping

### Phase 3 — Market Data & Realtime 🔜 PLANNED

- Background price updater
- Redis price cache
- SignalR push
- Cache invalidation

---

## Design principles

- Transport concerns stay in API
- Application layer is framework-agnostic
- Domain is persistence-agnostic
- No leaking Result objects outside API
- Prefer explicit patterns over magic
- Optimize for refactoring, not shortcuts

---

## How to update this file

- Mark phases as DONE when completed
- Add new decisions as they are made
- Do not delete past decisions — supersede them
- Treat this as living documentation
