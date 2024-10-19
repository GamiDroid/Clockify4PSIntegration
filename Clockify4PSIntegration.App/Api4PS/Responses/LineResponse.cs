using System.Text.Json.Serialization;

namespace Clockify4PSIntegration.App.Api4PS.Responses;

public record LineResponse(
    string? Key,
    int Year,
    int Week,
    [property: JsonPropertyName("supply_company")] string? SupplyingCompany,
    [property: JsonPropertyName("employee_no")] string? EmployeeNo,
    [property: JsonPropertyName("line_no")] int LineNo,
    [property: JsonPropertyName("receiving_company")] string? ReceivingCompany,
    [property: JsonPropertyName("line_template_code")] string? LineTemplateCode,
    [property: JsonPropertyName("line_template_description")] string? LineTemplateDescription,
    string? Type,
    [property: JsonPropertyName("object_no")] string? ObjectNo,
    [property: JsonPropertyName("object_description")] string? ObjectDescription,
    string? Element,
    [property: JsonPropertyName("element_description")] string? ElementDescription,
    [property: JsonPropertyName("cost_object")] string? CostObject,
    [property: JsonPropertyName("cost_object_description")] string? CostObjectDescription,
    string? Status,
    float Amount,
    [property: JsonPropertyName("total_line")] float TotalLine,
    string? Comment,
    int LineType,
    float Monday,
    float Tuesday,
    float Wednesday,
    float Thursday,
    float Friday,
    float Saturday,
    float Sunday);
