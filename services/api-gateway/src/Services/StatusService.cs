using ExpenseTracker.ApiGateway.Models;

namespace ExpenseTracker.ApiGateway.Services;

public sealed class StatusService : IStatusService
{
    public ApiStatus GetCurrentStatus()
    {
        return new ApiStatus(
            Service: "ExpenseTracker API Gateway",
            Status: "Healthy",
            Timestamp: DateTimeOffset.UtcNow);
    }
}
