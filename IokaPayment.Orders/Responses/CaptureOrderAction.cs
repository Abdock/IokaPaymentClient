using System.Text.Json.Serialization;

namespace IokaPayment.Orders.Responses;

public record CaptureOrderAction
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }
}