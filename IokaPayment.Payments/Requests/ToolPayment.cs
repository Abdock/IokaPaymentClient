using System.Text.Json.Serialization;
using IokaPayment.Payments.Enums;

namespace IokaPayment.Payments.Requests;

public record ToolPayment
{
    [JsonIgnore]
    public required string OrderId { get; init; }

    [JsonPropertyName("tool_type")]
    public required ToolType ToolType { get; init; }

    [JsonPropertyName("apple_pay")]
    public ApplePay? ApplePay { get; init; }

    [JsonPropertyName("google_pay")]
    public GooglePay? GooglePay { get; init; }
}