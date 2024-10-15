namespace Clockify4PSIntegration.App.Api4PS;

public class Api4PSService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<UserInfoResponse> GetUserInfoAsync(CancellationToken cancellationToken = default)
    {
        return _httpClient.GetFromJsonAsync<UserInfoResponse>("_api/userinfo", cancellationToken)!;
    }
}
