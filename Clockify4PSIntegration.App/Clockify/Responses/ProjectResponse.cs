namespace Clockify4PSIntegration.App.Clockify.Responses;

public record ProjectResponse(
    string Id,
    string WorkspaceId,
    string Name,
    string ClientId,
    string ClientName,
    string Color,
    bool Archived,
    string Duration,
    string Note) : BaseResponse;
