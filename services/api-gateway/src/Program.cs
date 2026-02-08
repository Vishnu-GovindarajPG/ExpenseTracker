var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new ExpenseTracker.ApiGateway.ApiStatus(
    "ExpenseTracker API Gateway",
    "Healthy",
    DateTimeOffset.UtcNow)))
    .WithName("GetStatus");

app.MapHealthChecks("/health");

app.Run();
public partial class Program { }
