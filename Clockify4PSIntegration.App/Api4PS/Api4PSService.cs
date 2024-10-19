using Clockify4PSIntegration.App.Api4PS.Request;
using Clockify4PSIntegration.App.Api4PS.Responses;

namespace Clockify4PSIntegration.App.Api4PS;

public class Api4PSService(
    HttpClient httpClient,
    IConfiguration configuration)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;

    public Task<UserInfoResponse> GetUserInfoAsync(CancellationToken cancellationToken = default)
    {
        return _httpClient.GetFromJsonAsync<UserInfoResponse>("_api/userinfo", cancellationToken)!;
    }

    public Task<ProjectResponse[]?> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        var companyName = _configuration["4PS:CompanyName"];
        return _httpClient.GetFromJsonAsync<ProjectResponse[]>($"_api/companies/{companyName}/projects", cancellationToken);
    }

    public Task<LineResponse[]?> GetLinesAsync(int year, int week, CancellationToken cancellationToken = default)
    {
        var requestUri = $"/_api/hours/my/{year}-{week}/lines";
        return _httpClient.GetFromJsonAsync<LineResponse[]>(requestUri, cancellationToken);
    }

    public async Task<LineResponse> CreateLineAsync(CreateLineRequest request, CancellationToken cancellationToken = default)
    {
        // validation...

        var companyName = _configuration["4PS:CompanyName"] ?? "<Empty Company>";

        var internalRequest = new CreateLineInternalRequest(
            Year: request.Year,
            Week: request.Week,
            ObjectNo: request.ObjectNo,
            Element: request.Element,
            Monday: request.Monday,
            Tuesday: request.Tuesday,
            Wednesday: request.Wednesday,
            Thursday: request.Thursday,
            Friday: request.Friday,
            Saturday: request.Saturday,
            Sunday: request.Sunday,
            Comment: request.Comment,
            ReceivingCompany: companyName,
            LineNo: -1);

        var requestUri = $"/_api/hours/my/{internalRequest.Year}-{internalRequest.Week}/lines";
        var response = await _httpClient.PostAsJsonAsync(requestUri, internalRequest, cancellationToken);

        response.EnsureSuccessStatusCode();

        var lineResponse = await response.Content.ReadFromJsonAsync<LineResponse>(cancellationToken);

        return lineResponse!;
    }
}


