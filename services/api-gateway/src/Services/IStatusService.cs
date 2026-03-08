using ExpenseTracker.ApiGateway.Models;

namespace ExpenseTracker.ApiGateway.Services;

public interface IStatusService
{
    ApiStatus GetCurrentStatus();
}
