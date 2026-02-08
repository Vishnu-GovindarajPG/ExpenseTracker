using System.Net.Http.Json;
using ExpenseTracker.ApiGateway;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace ExpenseTracker.ApiGateway.Tests;

public sealed class ApiGatewayTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiGatewayTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetRoot_ReturnsStatusPayload()
    {
        var response = await _client.GetAsync("/");

        response.EnsureSuccessStatusCode();

        var payload = await response.Content.ReadFromJsonAsync<ApiStatusResponse>();

        Assert.NotNull(payload);
        Assert.Equal("ExpenseTracker API Gateway", payload!.Service);
        Assert.Equal("Healthy", payload.Status);
    }

    private sealed record ApiStatusResponse(string Service, string Status, DateTimeOffset Timestamp);
}
