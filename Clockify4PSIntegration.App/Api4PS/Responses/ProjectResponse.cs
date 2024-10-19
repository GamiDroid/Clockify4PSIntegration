using System.Text.Json.Serialization;

namespace Clockify4PSIntegration.App.Api4PS.Responses;

public record ProjectResponse(
    string? Code,
    string? Key,
    string? Company,
    string? Type,
    bool TypeSpecified,
    string? Description,
    string? Address,
    [property: JsonPropertyName("customer_name")] string? CustomerName);
