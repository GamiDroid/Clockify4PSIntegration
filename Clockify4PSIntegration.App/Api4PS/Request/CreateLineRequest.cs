using System.Text.Json.Serialization;

namespace Clockify4PSIntegration.App.Api4PS.Request;

public record CreateLineRequest
{
    public required int Year { get; init; }
    public required int Week { get; init; }
    public required string ObjectNo { get; init; }
    public string? Element { get; init; }
    public int? Monday { get; init; }
    public int? Tuesday { get; init; }
    public int? Wednesday { get; init; }
    public int? Thursday { get; init; }
    public int? Friday { get; init; }
    public int? Saturday { get; init; }
    public int? Sunday { get; init; }
    public string? Comment { get; init; }
}

internal record CreateLineInternalRequest(
    int Year,
    int Week,
    [property: JsonPropertyName("object_No")] string ObjectNo,
    string? Element,
    int? Monday,
    int? Tuesday,
    int? Wednesday,
    int? Thursday,
    int? Friday,
    int? Saturday,
    int? Sunday,
    string? Comment,
    [property: JsonPropertyName("receiving_Company")] string ReceivingCompany,
    [property: JsonPropertyName("line_No")] int LineNo);
