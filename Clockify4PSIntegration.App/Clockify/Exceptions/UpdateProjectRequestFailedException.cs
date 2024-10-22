namespace Clockify4PSIntegration.App.Clockify.Exceptions;

[Serializable]
internal class UpdateProjectRequestFailedException(string? message, HttpResponseMessage response) : Exception(message)
{
    public HttpResponseMessage? Response { get; } = response;
}
