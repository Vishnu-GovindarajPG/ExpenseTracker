namespace ExpenseTracker.ApiGateway;

public record ApiStatus(string Service, string Status, DateTimeOffset Timestamp);
