namespace Clockify4PSIntegration.App.Api4PS;

public record LoginResponse(string Token, DateTime Expires, bool Succeeded, bool IsLockedOut, bool IsNotAllowed, bool RequiresTwoFactor);
