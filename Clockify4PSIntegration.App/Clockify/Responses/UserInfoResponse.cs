namespace Clockify4PSIntegration.App.Clockify.Responses;

public record UserInfoResponse(
    string Id,
    string Email,
    string Name,
    string? ProfilePicture,
    string ActiveWorkspace,
    string DefaultWorkspace,
    string Status) : BaseResponse;
