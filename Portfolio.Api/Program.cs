using Carter;
using Microsoft.AspNetCore.Http.Metadata;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddSerilog((services, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(builder.Configuration);
});

//builder.AddNpgsqlDbContext<PortfolioDbContext>("portfolio");

builder.Services.AddCarter();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.TagActionsBy(api =>
    {
        // 1) Prefer WithTags(...) metadata from minimal APIs
        var tags = api.ActionDescriptor.EndpointMetadata
            .OfType<ITagsMetadata>()
            .SelectMany(t => t.Tags)
            .Distinct()
            .ToArray();

        if (tags.Length > 0)
            return tags;

        // 2) Next best: GroupName if you used WithGroupName(...)
        if (!string.IsNullOrWhiteSpace(api.GroupName))
            return new[] { api.GroupName };

        // 3) Fallback
        return new[] { "Endpoints" };
    });

});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.Run();