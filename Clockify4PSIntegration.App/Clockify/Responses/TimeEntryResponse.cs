namespace Clockify4PSIntegration.App.Clockify.Responses;

public record TimeEntryResponse(
    string Id,
    string WorkspaceId,
    string UserId,
    TimeInterval TimeInterval,
    string? Description,
    string? ProjectId,
    string? TaskId,
    string[]? TagIds,
    string Type) : BaseResponse;
