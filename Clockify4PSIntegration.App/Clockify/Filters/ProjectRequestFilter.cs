namespace Clockify4PSIntegration.App.Clockify.Filters;

public class ProjectRequestFilter(string WorkspaceId)
{
    public string WorkspaceId { get; } = WorkspaceId;
    public bool? Archived { get; set; }
}
