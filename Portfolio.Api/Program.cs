using Carter;
using Serilog;
using Portfolio.Infrastructure.Data;
using Scalar.AspNetCore;
using Portfolio.Application;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSerilog((services, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(builder.Configuration);
});

builder.AddNpgsqlDbContext<PortfolioDbContext>("portfolio-db");

builder.Services.AddApplication();

builder.Services.AddCarter();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Portfolio API V1");
    });

    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });

    app.MapScalarApiReference();
}

app.MapCarter();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.Run();