namespace Clockify4PSIntegration.App.Clockify.Responses;

public record ProjectTaskResponse(string Id, string Name, string ProjectId) : BaseResponse;
