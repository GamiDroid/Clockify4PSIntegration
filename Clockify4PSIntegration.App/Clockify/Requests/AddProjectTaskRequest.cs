namespace Clockify4PSIntegration.App.Clockify.Requests;

public class AddProjectTaskRequest(string workspaceId, string projectId, string name)
{
    public string WorkspaceId { get; } = workspaceId;
    public string ProjectId { get; } = projectId;
    public string Name { get; } = name;
}