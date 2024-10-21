using Clockify4PSIntegration.App.Clockify.Filters;
using Clockify4PSIntegration.App.Clockify.Responses;
using Microsoft.Extensions.Primitives;

namespace Clockify4PSIntegration.App.Clockify;

public sealed class ClockifyService
    (HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<UserInfoResponse> GetUserInfoAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetFromJsonAsync<UserInfoResponse>("/api/v1/user", cancellationToken);
        return response!;
    }

    public async Task<List<TimeEntryResponse>> GetTimeEntriesAsync(TimeEntryRequestFilter filter, CancellationToken cancellationToken = default)
    {
        var queryParams = new Dictionary<string, StringValues>();
        if (filter.Start is not null) { queryParams.Add("start", filter.Start!.Value.ToString(c_dateTimeFormat)); }
        if (filter.End is not null) { queryParams.Add("end", filter.End!.Value.ToString(c_dateTimeFormat)); }
        if (filter.GetWeekBefore is not null) { queryParams.Add("get-week-before", filter.GetWeekBefore!.Value.ToString(c_dateTimeFormat)); }

        var query = QueryString.Create(queryParams);
        var requestUri = $"/api/v1/workspaces/{filter.WorkspaceId}/user/{filter.UserId}/time-entries{query}";

        var response = await _httpClient.GetFromJsonAsync<List<TimeEntryResponse>>(requestUri, cancellationToken);
        return response!;
    }

    public async Task<List<TimeEntryResponse>> GetTimeEntriesAsync(string workspaceId, string userId, CancellationToken cancellationToken = default)
    {
        var filter = new TimeEntryRequestFilter(workspaceId, userId);
        var response = await GetTimeEntriesAsync(filter, cancellationToken);
        return response;
    }

    public async Task<List<ProjectResponse>> GetProjectsAsync(ProjectRequestFilter filter, CancellationToken cancellationToken = default)
    {
        var queryParams = new Dictionary<string, StringValues>();
        if (filter.Archived is not null) { queryParams.Add("archived", filter.Archived.ToString()); }

        var query = QueryString.Create(queryParams);

        var requestUri = $"/api/v1/workspaces/{filter.WorkspaceId}/projects{query}";
        var response = await _httpClient.GetFromJsonAsync<List<ProjectResponse>>(requestUri, cancellationToken);
        return response!;
    }

    public async Task<List<ProjectResponse>> GetProjectsAsync(string workspaceId, CancellationToken cancellationToken = default)
    {
        var filter = new ProjectRequestFilter(workspaceId);
        var response = await GetProjectsAsync(filter, cancellationToken);
        return response;
    }

    public async Task<ProjectResponse> GetProjectByIdAsync(string workspaceId, string projectId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"/api/v1/workspaces/{workspaceId}/projects/{projectId}";
        var response = await _httpClient.GetFromJsonAsync<ProjectResponse>(requestUri, cancellationToken);
        return response!;
    }

    //public Task<ProjectResponse> CreateProjectAsync(CancellationToken cancellationToken = default)
    //{
    //    return Task.FromResult();
    //}

    private const string c_dateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
}

public class CreateProjectRequest(string workspaceId, string name)
{
    public string WorkspaceId { get; } = workspaceId;
    public string Name { get; } = name;


}