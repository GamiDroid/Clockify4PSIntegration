namespace Clockify4PSIntegration.App.Clockify.Requests;

public class UpdateProjectRequest(string workspaceId, string projectId)
{
    public string WorkspaceId { get; } = workspaceId;
    public string ProjectId { get; } = projectId;
    public string? Name { get; set; }
    public string? ClientId { get; set; }
    public string? Note { get; set; }
}
