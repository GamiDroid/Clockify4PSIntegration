
namespace Clockify4PSIntegration.App.Clockify;

public class ClockifyApiKeyAuthenticationHandler(
    IConfiguration configuration) : DelegatingHandler
{
    private readonly IConfiguration _configuration = configuration;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var apiKey = _configuration["Clockify:ApiKey"] ?? "<Empty Clockify Key>";
        request.Headers.Add("X-Api-Key", apiKey);

        return base.SendAsync(request, cancellationToken);
    }
}