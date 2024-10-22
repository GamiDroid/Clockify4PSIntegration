using System.Text.Json.Serialization;

namespace Clockify4PSIntegration.App.Clockify.Responses;

public record BaseResponse
{
    [JsonExtensionData]
    public IDictionary<string, object>? AdditionalProperties { get; set; }
}