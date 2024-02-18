using System.Text.Json.Serialization;

namespace IokaPayment.General.Models;

public record PaymentAction
{
    [JsonPropertyName("url")]
    public required Uri Url { get; init; }
}