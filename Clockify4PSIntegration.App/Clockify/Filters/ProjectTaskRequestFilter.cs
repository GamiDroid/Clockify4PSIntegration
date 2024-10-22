namespace Clockify4PSIntegration.App.Clockify.Filters;

public class ProjectTaskRequestFilter(string workspaceId, string projectId)
{
    public string WorkspaceId { get; } = workspaceId;
    public string ProjectId { get; } = projectId;
}
