var builder = DistributedApplication.CreateBuilder(args);
var redis = builder.AddRedis("redis");

var db = builder.AddPostgres("portfolio")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.Portfolio_Api>("api")
       .WithReference(redis)
       .WaitFor(redis)
       .WithReference(db)
       .WaitFor(db);

builder.Build().Run();
