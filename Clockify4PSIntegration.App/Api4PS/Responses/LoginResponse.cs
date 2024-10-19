namespace Clockify4PSIntegration.App.Api4PS.Responses;

public record LoginResponse(string Token, DateTime Expires, bool Succeeded, bool IsLockedOut, bool IsNotAllowed, bool RequiresTwoFactor);
