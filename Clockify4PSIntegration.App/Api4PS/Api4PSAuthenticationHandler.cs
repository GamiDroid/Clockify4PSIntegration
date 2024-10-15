
using System.Net.Http.Headers;

namespace Clockify4PSIntegration.App.Api4PS;

public class Api4PSAuthenticationHandler(ITokenAuthenticationService authenticationService) : DelegatingHandler
{
    private readonly ITokenAuthenticationService _authenticationService = authenticationService;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!request.RequestUri!.LocalPath.Equals("_api/account/login"))
        {
            var tokenResponse = await _authenticationService.GetAccessTokenAsync(cancellationToken);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.Token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
