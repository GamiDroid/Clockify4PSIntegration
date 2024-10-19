namespace Clockify4PSIntegration.App.Api4PS.Responses;

public record UserInfoResponse(
    bool ShowLeaveOverview,
    float NormDays,
    float NormHours,
    string? StartupWeek,
    string? StartingDayOfWeek,
    bool IsBasedOnTime,
    bool GenerateLinesEnabled,
    int ReportId,
    bool CopyHoursFromWorkOrders,
    string? Discipline,
    string? Username,
    string? DisplayName,
    string? Company,
    string? UserId,
    string? EmployeeNo,
    string? Cao);
