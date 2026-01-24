var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var portfolioDb = builder.AddPostgres("database")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithHostPort(5432)
    .WithDataVolume()
    .WithPgAdmin()
    .AddDatabase("portfolio-db");

builder.AddProject<Projects.Portfolio_Api>("portfolio-api")
       .WithReference(redis)
       .WaitFor(redis)
       .WithReference(portfolioDb)
       .WaitFor(portfolioDb);

builder.Build().Run();
