var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithHostPort(6379)
    .WithDataVolume();

var database = builder.AddPostgres("database")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithHostPort(5432)
    .WithDataVolume()
    .WithPgAdmin()
    .AddDatabase("portfolio-db");

builder.AddProject<Projects.Portfolio_Api>("portfolio-api")
       .WithReference(redis)
       .WaitFor(redis)
       .WithReference(database)
       .WaitFor(database);

builder.Build().Run();
