namespace ExpenseTracker.ApiGateway.Models;

public sealed record ApiStatus(string Service, string Status, DateTimeOffset Timestamp);
