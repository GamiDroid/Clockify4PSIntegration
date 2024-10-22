namespace Clockify4PSIntegration.App.Clockify.Requests;

public class CreateProjectRequest(string workspaceId, string name)
{
    public string WorkspaceId { get; } = workspaceId;
    public string Name { get; } = name;
    public string? ClientId { get; set; }
    public string? Note { get; set; }
    public ProjectTask[]? Tasks { get; set; }
}

public class ProjectTask(string name)
{
    public string Name { get; } = name;
}