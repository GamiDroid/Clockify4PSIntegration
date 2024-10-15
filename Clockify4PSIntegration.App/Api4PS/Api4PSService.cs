using Microsoft.AspNetCore.Identity.Data;

namespace Clockify4PSIntegration.App.Api4PS;

public class Api4PSService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<LoginResponse> LoginAsync(string username, string password, CancellationToken cancellationToken)
    {
        LoginRequest request = new(username, password, "HTP");

        var response = await _httpClient.PostAsJsonAsync("_api/account/login", request, cancellationToken);

        response.EnsureSuccessStatusCode();

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);

        return loginResponse!;
    }

    public Task<UserInfoResponse> GetUserInfoAsync(CancellationToken cancellationToken = default)
    {
        return _httpClient.GetFromJsonAsync<UserInfoResponse>("_api/userinfo", cancellationToken)!;
    }
}

public record LoginRequest(string Username, string Password, string Client);
public record LoginResponse(string Token, DateTime Expires, bool Succeeded, bool IsLockedOut, bool IsNotAllowed, bool RequiresTwoFactor);
