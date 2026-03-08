using ExpenseTracker.ApiGateway.Models;
using ExpenseTracker.ApiGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.ApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService)
    {
        _statusService = statusService;
    }

    [HttpGet]
    [ProducesResponseType<ApiStatus>(StatusCodes.Status200OK)]
    public ActionResult<ApiStatus> GetStatus()
    {
        var status = _statusService.GetCurrentStatus();
        return Ok(status);
    }
}
