namespace Clockify4PSIntegration.App.Clockify.Filters;

public class TimeEntryRequestFilter(string WorkspaceId, string UserId)
{
    public string WorkspaceId { get; } = WorkspaceId;
    public string UserId { get; } = UserId;
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public DateTime? GetWeekBefore { get; set; }
}
