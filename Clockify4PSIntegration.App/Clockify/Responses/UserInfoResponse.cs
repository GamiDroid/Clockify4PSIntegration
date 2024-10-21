namespace Clockify4PSIntegration.App.Clockify.Responses;

public record UserInfoResponse(
    string Id,
    string Email,
    string Name,
    string? ProfilePicture,
    string ActiveWorkspace,
    string DefaultWorkspace,
    //Settings Settings,
    string Status);

//public class Settings
//{
//    public string weekStart { get; set; }
//    public string timeZone { get; set; }
//    public string timeFormat { get; set; }
//    public string dateFormat { get; set; }
//    public bool sendNewsletter { get; set; }
//    public bool weeklyUpdates { get; set; }
//    public bool longRunning { get; set; }
//    public bool scheduledReports { get; set; }
//    public bool approval { get; set; }
//    public bool pto { get; set; }
//    public bool alerts { get; set; }
//    public bool reminders { get; set; }
//    public bool timeTrackingManual { get; set; }
//    public Summaryreportsettings summaryReportSettings { get; set; }
//    public bool isCompactViewOn { get; set; }
//    public string dashboardSelection { get; set; }
//    public string dashboardViewType { get; set; }
//    public bool dashboardPinToTop { get; set; }
//    public int projectListCollapse { get; set; }
//    public bool collapseAllProjectLists { get; set; }
//    public bool groupSimilarEntriesDisabled { get; set; }
//    public string myStartOfDay { get; set; }
//    public bool projectPickerTaskFilter { get; set; }
//    public string lang { get; set; }
//    public bool multiFactorEnabled { get; set; }
//    public string theme { get; set; }
//    public bool scheduling { get; set; }
//    public bool onboarding { get; set; }
//    public bool showOnlyWorkingDays { get; set; }
//}

//public class Summaryreportsettings
//{
//    public string group { get; set; }
//    public string subgroup { get; set; }
//}
