namespace Clockify4PSIntegration.App.Clockify.Requests;

public record DeleteProjectTaskRequest(string WorkspaceId, string ProjectId, string TaskId);