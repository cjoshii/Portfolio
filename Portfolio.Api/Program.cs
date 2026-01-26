using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Portfolio.Api.Extensions;
using Portfolio.Application;
using Portfolio.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Host.UseSerilog((ctx, services, cfg) =>
{
    cfg
    .ReadFrom.Configuration(ctx.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext();
});

builder.AddInfrastructure();

builder.Services.ConfigureSettingsOptions();

builder.Services.AddMapper();

builder.Services.AddCarter();

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.AddOpenApiWithAuth();

builder.Services.AddApplication();

var app = builder.Build();

app.UseRequestContextLogging();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerWithUi();
}

app.MapCarter();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
