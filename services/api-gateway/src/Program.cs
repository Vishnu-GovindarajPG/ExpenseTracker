using ExpenseTracker.ApiGateway;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new ApiStatus(
    "ExpenseTracker API Gateway",
    "Healthy",
    DateTimeOffset.UtcNow)))
    .WithName("GetStatus");

app.MapHealthChecks("/health");

app.Run();

namespace ExpenseTracker.ApiGateway;

public record ApiStatus(string Service, string Status, DateTimeOffset Timestamp);

public partial class Program { }
